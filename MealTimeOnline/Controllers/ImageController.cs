using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Image = MealTimeOnline.Models.Common.Image;

namespace MealTimeOnline.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image/Placeholder
        public ActionResult Placeholder(int width, int height, string text)
        {
            Bitmap res = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(res);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, width, height));

            string str = text ?? $"{width}x{height}";

            float lo = 1f, hi = width / 2.5f;
            while ((hi - lo) > 1e-2)
            {
                float mid = (lo + hi) / 2f;
                SizeF sx = g.MeasureString(str, new Font("微软雅黑", mid));
                if (sx.Width < (width*0.92f) && sx.Height < (height*0.96f))
                    lo = mid;
                else
                    hi = mid;
            }

            Font font = new Font("微软雅黑", lo);
            SizeF size = g.MeasureString(str, font);

            g.DrawString(str, font, Brushes.Gray, (width - size.Width) / 2f, (height - size.Height) / 2f);
            MemoryStream ms = new MemoryStream();
            res.Save(ms, ImageFormat.Png);
            return File(ms.GetBuffer(), @"image/png");
        }
    }
}
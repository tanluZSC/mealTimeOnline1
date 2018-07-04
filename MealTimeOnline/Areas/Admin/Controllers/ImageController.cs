using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image/Placeholder
        public ActionResult Placeholder(int width, int height, string text)
        {
            Bitmap res = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(res);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //g.Clear(Color.Transparent);
            g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, width, height));

            string str = text ?? $"{width}x{height}";

            float lo = 1f, hi = width / 2.5f;
            while ((hi - lo) > 1e-2)
            {
                float mid = (lo + hi) / 2f;
                SizeF sx = g.MeasureString(str, new Font("微软雅黑", mid));
                if (sx.Width < (width * 0.92f) && sx.Height < (height * 0.96f))
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

        // TODO
        // GET: Image/Imgx/{setting}/{text}
        public ActionResult Imgx(string setting, string text)
        {
            string[] settings = setting.Split(',');
            Regex reg = new Regex(@"^(?<key>.+?)_(?<value>.+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int width = 0, height = 0, opacity = 100;
            foreach (var s in settings)
            {
                var config = s.Trim();
                if (!reg.IsMatch(s))
                    throw new Exception($"Config params '{config}' has error");
                var matchRes = reg.Match(config);
                var k = matchRes.Groups["key"].ToString();
                var v = matchRes.Groups["value"].ToString();
                if (k == "w") width = int.Parse(v);
                else if (k == "h") height = int.Parse(v);
                else if (k == "o") opacity = int.Parse(v);
            }
            opacity = opacity * 255 / 100;
            Bitmap res = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(res);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(new SolidBrush(Color.FromArgb(opacity, Color.White)), new Rectangle(0, 0, width, height));

            string str = text ?? $"{width}x{height}";

            float lo = 1f, hi = width / 2.5f;
            while ((hi - lo) > 1e-2)
            {
                float mid = (lo + hi) / 2f;
                SizeF sx = g.MeasureString(str, new Font("微软雅黑", mid));
                if (sx.Width < (width * 0.92f) && sx.Height < (height * 0.96f))
                    lo = mid;
                else
                    hi = mid;
            }

            Font font = new Font("微软雅黑", lo);
            SizeF size = g.MeasureString(str, font);

            g.DrawString(str, font, new SolidBrush(Color.FromArgb(0x3a, 0x87, 0xad)), (width - size.Width) / 2f, (height - size.Height) / 2f);
            MemoryStream ms = new MemoryStream();
            res.Save(ms, ImageFormat.Png);
            return File(ms.GetBuffer(), @"image/png");
        }
    }
}

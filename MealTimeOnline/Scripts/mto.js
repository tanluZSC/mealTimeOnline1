/*
*   Created by AK4TRL ‎2016-‎11‎-‎29‎ 00:50:50
*   Modify in 2017-04
*/
//侧边滚动条
$('html').niceScroll({
    styler: "fb",
    cursorcolor: "#cccccc",
    cursorwidth: '6',
    cursorborderradius: '0px',
    background: '#424f63',
    spacebarenabled: false,
    cursorborder: '0',
    zindex: '1000'
});
$('.menu').hide();
function addLoginAttr() {
    if ($('#nav-left')[0].innerText == "Log in") {
        $('#nav-left').attr("data-toggle", "modal");
        $('#nav-left').attr("data-target", "#loginModal");
    }
}
$('#myCarousel').carousel({
    pause: 'none'
});
//轮播图两边按钮隐藏/显示
var getMycarousel = $('#myCarousel'),
    getLRControl = $('#LRControls');
getLRControl.hide();
getMycarousel.on("mouseenter mouseleave", function (event) {
    if (event.type == "mouseenter") {
        t = setInterval(function () {
            getLRControl.fadeIn(500);
        }, 100);
    }
    else if (event.type == "mouseleave") {
        clearInterval(t);
        getLRControl.fadeOut(500);
    }
})
//
//轮播图加载条
if (getMycarousel.find('.carouselTimer').length == 0)
    getMycarousel.append('<div class="carouselTimer"></div>');
var bt = getMycarousel.find('.carouselTimer'),
    ebt = null;
if (bt.length > 0) {
    bt.css({ 'width': '0%' });
};
function fun() {
    bt.animate({ 'width': '100%' }, 5000, function () {
        $(this).css("width", '0%');
        ebt = setTimeout("fun()", 0);
    });
}
ebt = setTimeout("fun()", 0);

//若点击next,pre重设加载条
getLRControl.each(function () {
    $(this).on("click", function () {
        console.log(bt.length);
        clearTimeout(ebt);
        if (bt.length > 0) {
            bt.stop();
            bt.css({ 'width': '0%' });
        }
        ebt = setTimeout("fun()", 0);
    })
})
//网页失去焦点后加载条停止

//用户登陆后图标,以及登陆信息
var getCycleIcon = $('#cycle-icon'),
    getMember = $('.member'),
    tmpTimer = null,
    tmpTimer2 = null;
getMember.on("mouseenter mouseleave", function (e) {
    if (e.type == "mouseenter") {
        tmpTimer = setTimeout(function () {
            getCycleIcon.animate({ "height": "70px", "width": "70px", "border-radius": "35px", "top": "40px", "left": "10px" })
            $(".menu").css({ 'left': '-40px' }, { 'visibility': 'visible' });
            $(".menu").slideDown(410);
        }, 400);
        clearTimeout(tmpTimer2)
    }
    else {
        tmpTimer2 = setTimeout(function () {
            getCycleIcon.animate({ "height": "50px", "width": "50px", "border-radius": "25px", "top": "13px", "left": "20px" });
            $(".menu").slideUp(410);
        }, 400);
        clearTimeout(tmpTimer)
    }
})
//选择食堂,位置显示
//console.log($('.Business-sorts .current').html());
$('#canteenName').html($('.Business-sorts .current').html());
function showTab(contentClassName, index) {
    // switch content
    var content = document.getElementsByClassName(contentClassName);
    for (var i = 0; i < content.length; ++i) {
        if (content[i].classList.contains('rstbox-current'))
            content[i].classList.remove('rstbox-current');
    }
    content[index].classList.add('rstbox-current');
    $('#canteenName').html($('.Business-sorts .current').html());
}

function showSelected() {
    if (event.target.classList.contains('current'))
        return false;
    var targetParentNode = event.target.parentNode;
    for (var curNode = targetParentNode.parentNode.firstElementChild; curNode; curNode = curNode.nextElementSibling) {
        if (curNode.firstElementChild.classList.contains('current'))
            curNode.firstElementChild.classList.remove('current');
    }
    event.target.classList.add('current');
}

function showCart(obj) {
    // show cart
    var content = document.getElementsByClassName('cart');
    if (content[0].classList.contains('cart-current') == false)
        content[0].classList.add('cart-current');

    var foodId = $(obj).parent().attr('data-food').trim();
    var tmp = $('#cart-basket .cart-info').find('div[data-food=' + foodId + ']');
    console.log(tmp);
    if (tmp.length == 0) {
        //show cart-info
        $('#cart-basket')
            .append('<div class="cart-info" data-food="' +
                foodId +
                '">' +
                '<span style="line-height:40px">' +
                $(obj).parent().attr('data-food-name') +
                '</span><span style="line-height:40px" class="pull-right">' +
                $(obj).parent().attr('data-food-cnt') +
                '</span>' +
                '</div>');

        //change index
        var eles = document.getElementById("cart-basket");
        var m = parseInt(eles.style.top);
        eles.style.top = (m + (-40)) + 'px';
    }

    //remove disabled
    $('#footercheck').removeClass('disabled');
    $('#footercheck').removeAttr("disabled");
}

function UpdateCard(id, cnt) {
    var sum = 0;
    $('#cart-basket .cart-info').each(function () {
        var flag = true;
        if ($(this).attr('data-food') == id) {
            $(this).find('.pull-right').eq(0).html(cnt);
            if (cnt == 0) {
                var pa = document.getElementById("cart-basket");
                pa.style.top = (parseInt(pa.style.top) + 40) + 'px';
                $(this).remove();
                flag = false;
            }
        }
        if (flag) {
            var fid = parseInt($(this).attr('data-food'));
            sum += $('div[data-food=' + fid + ']').eq(0).attr('data-food-cnt') * $('div[data-food=' + fid + ']').eq(0).attr('data-food-price');
        }
    });
    $('#showprices').html(sum);
    if (sum == 0) {
        $('#footercheck').addClass("disabled");
        $('#footercheck').attr('disabled', "true");
    }
}

function cartclear(contentCheckButton) {
    var eles = document.getElementById("cart-basket");
    eles.style.top = (-40) + 'px';

    cnt = 0;

    $('.cart-basket .cart-info').each(function () {
        $(this).remove();
    });

    $('.food-cnt').each(function () {
        $(this).attr('data-food-cnt', 0);
    });
    $('.food-add-cart').each(function () {
        $(this).show();
    });
    $('.food-cart-cnt').each(function () {
        $(this).hide();
    });

    $('#showprices').html(0);

    //button change
    $("#footercheck").addClass("disabled");
    $('#footercheck').attr('disabled', "true");
}

$('.canteen-box').each(function () {
    $(this).click(function () {
        var orderlist = $(this).attr('data-canteen');
        console.log(orderlist);
        $.ajax({
            url: '/Order/addToController',
            data: JSON.stringify({ 'id': 1, 'canteenName': orderlist }),
            type: 'POST',
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            success: function (jsonResult) {
                alert(jsonResult);
            }
        });
    });
});

function UpdateFood(id, cnt) {
    $.ajax({
        url: '/Order/Modify',
        data: JSON.stringify({ 'id': id, 'cnt': cnt }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (jsonResult) {
            alert(jsonResult);
        }
    });
}

$('.food-add-cart').each(function () {
    var p = $(this).parent();
    $(this).click(function () {
        p.find('.food-add-cart').hide();
        p.find('.food-cart-cnt').show();
        p.attr('data-food-cnt', 1);
        p.find('.food-cart-num').val(1);
        UpdateFood(p.attr('data-food'), p.attr('data-food-cnt'));
        showCart(this);
        UpdateCard(-1, 0);
    });
});
$('.food-cart-cnt').each(function () {
    var p = $(this).parent();
    var id = p.attr('data-food');
    p.find('.pull-right').eq(0).click(function () {
        var cnt = parseInt(p.attr('data-food-cnt'));
        cnt = Math.min(99, cnt + 1);
        if (cnt > 99) {
            alert('Cant order over 99.');
        }
        p.attr('data-food-cnt', cnt);
        p.find('.food-cart-num').val(cnt);
        UpdateFood(id, cnt);
        UpdateCard(id, cnt);
    });
    p.find('.pull-left').eq(0).click(function () {
        var cnt = parseInt(p.attr('data-food-cnt'));
        cnt = Math.max(0, cnt - 1);
        if (cnt <= 0) {
            p.find('.food-cart-cnt').eq(0).hide();
            p.find('.food-add-cart').eq(0).show();
        }
        p.attr('data-food-cnt', cnt);
        p.find('.food-cart-num').val(cnt);
        UpdateFood(id, cnt);
        UpdateCard(id, cnt);
    });
});

//个人中心 > 个人资料 > 地址没有添加时的更改

$('#fucktheaddress').html(function () {
    var reg = /\{\{(.+?)\}\}/g,
        tmpstr = $('#fucktheaddress').html();
    var tmpflag = tmpstr.match(reg);
    if (tmpflag == "{{fuck}}") {
        tmpstr = tmpstr.replace('{{' + 'fuck' + '}}', '<a href="Addresses">请添加</a>');
        //console.log(tmpstr);
    }
    return tmpstr;
});

//购物车checkout页面地址选择
$('.select_address:first').addClass('active');
$('.select_address').each(function () {
    $(this).click(function () {
        if ($(this).hasClass('active')) { }
        else {
            $(this).parent().find('.active').removeClass('active');
            $(this).addClass('active');
        }
    })
})

//若没有设置地址，则拒绝访问
$('#btnToSubmit').attr("disabled",function (e) {
    if ($(this).attr('data-addressCount') == '0') {
        return true;
        alert("请先填写所在地址");
    }
    return false;
});
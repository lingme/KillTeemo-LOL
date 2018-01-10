$(function () {
    var opts = {
        lines: 13,
        length: 7,
        width: 4,
        radius: 10,
        corners: 1,
        rotate: 0,
        color: '#2FC9C8',
        speed: 1,
        trail: 60,
        shadow: false,
        hwaccel: false,
        className: 'spinner',
        zIndex: 2e9,
        top: 'auto',
        left: 'auto'
    };
    var target = document.getElementById('foo');
    var spinner = new Spinner(opts).spin(target);
});

var abc = getBroswer();
$("#t_iframe").bind("load", function () {
    if (abc.broswer != 'IE') {
        $("#bg_grid").hide();
    }
});

function getBroswer() {
    var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    var s;
    (s = ua.match(/edge\/([\d.]+)/)) ? Sys.edge = s[1] :
    (s = ua.match(/rv:([\d.]+)\) like gecko/)) ? Sys.ie = s[1] :
    (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
    (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
    (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
    (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
    (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

    if (Sys.edge) return { broswer: "Edge", version: Sys.edge };
    if (Sys.ie) return { broswer: "IE", version: Sys.ie };
    if (Sys.firefox) return { broswer: "Firefox", version: Sys.firefox };
    if (Sys.chrome) return { broswer: "Chrome", version: Sys.chrome };
    if (Sys.opera) return { broswer: "Opera", version: Sys.opera };
    if (Sys.safari) return { broswer: "Safari", version: Sys.safari };

    return { broswer: "", version: "0" };
}


$(window).bind("resize", function () {
    var leftNum = window.innerWidth / 2 ;
    $(".spinner").css("left", leftNum).fadeIn(500);
});
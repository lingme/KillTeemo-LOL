//是否加载雪花JS文件（移动端屏蔽）
$(window).bind("load", function () {
    Updatewebsite();
    $(".content").mCustomScrollbar({
        setWidth: false,            
        setHeight: false,          
        setTop: 0,          
        setLeft: 0,                 
        axis: "y",             
        scrollInertia:0,
        scrollbarPosition: "inside",
        autoDraggerLength:true,
        autoExpandScrollbar:true,
        alwaysShowScrollbar:2,
        mouseWheel:{
            enable:true,
            scrollAmount:30,
            preventDefault:true,
            invert:false
        },
        scrollButtons:{
            enable:false,
            scrollType:"continuous",
            scrollSpeed:20,
            scrollAmount:40
        },
        advanced:{
            updateOnBrowserResize:true,
            updateOnContentResize:false,
            autoExpandHorizontalScroll:false,
            autoScrollOnFocus:false
        },
        callbacks:{
            onScrollStart:function(){},
            onScroll:function(){},
            onTotalScroll:function(){},
            onTotalScrollBack:function(){},
            onTotalScrollOffset:0,
            whileScrolling:false,
            whileScrollingInterval:30
        }
    });
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) >= 0) {
            flag = false;
            break;
        }
    }
    if (flag) {
        $.getScript("/KillTeemoJS/snow.js");
    }
});



//更新站点信息
function Updatewebsite() {
    var browsertype = getBroswer();
    $.ajax({
        'type': 'post',
        'url': '/Globals/UpdataWebsite',
        'data': { broType: browsertype.broswer },
        error: function () {
            console.log('Error : UpdataWebsite is error ');
        }
    });
}

//初始化BootStrap tooltip提示框
$(function () {
    $("[data-toggle='tooltip']").tooltip();
    if ($(document).attr("title") == 'KillTeemo - 召唤师查找') {
        search();
    }
});

//搜索按钮事件
function SearchClick() {
    if ($(document).attr("title") != 'KillTeemo - 召唤师查找') {
        window.location = '/Home/Search?name=' + $("#dataInput").val();
    }
    else {
        search();
    }
}

//搜索框enter事件
function inputKeydown(e) {
    if (e.keyCode == 13) {
        if ($(document).attr("title") != 'KillTeemo - 召唤师查找') {
            window.location = '/Home/Search?name=' + $("#dataInput").val();
        }
        else {
            search();
        }
    }
}

//搜索请求
function search() {
    if ($("#dataInput").val().replace(/[^\x00-\xff]/g, "**").length <= 16) {
        $.ajax({
            'async': true,
            'url': '/Home/Get_Aero_Player',
            'type': 'post',
            'datatype': 'json',
            'data': { player: $("#dataInput").val() },
            success: function (data) {
                var Json_ob = JSON.parse(replace_unicode(data));
                carete_table(Json_ob);
            }
        });
    }
    else {
        $("#ANII").text(" 超过ID字符限制");
    }
}

//监测搜索框输入长度提示
function OnInputValueLength() {
    if ($("#dataInput").val().replace(/[^\x00-\xff]/g, "**").length > 16) {
        $("#dataInput").attr('title', "超过ID字符限制，本次查询无效").tooltip('fixTitle').tooltip('show');
    } else {
        $("#dataInput").attr('title', " ").tooltip('fixTitle').tooltip('hide');
    }
}

//总线链接
function LinkAll(str) {
    if (str == "Tencent") {
        window.open("http://shang.qq.com/email/stop/email_stop.html?qq=2722821182&sig=a1c657365db7e82805ea4b2351081fc3ebcde159f8ae49b1&tttt=1");
    }
    else if (str == 'Info') {
        var abc = getBroswer();
        if (abc.broswer != 'IE') {
            window.open("/Home/ServicesInfo");
        } else {
            toastr.options = {
                "positionClass": "toast-bottom-full-width",
                "timeOut": "5000"
            };
            toastr.warning('抱歉，此页面暂时不支持 IE 浏览器，请使用其它游览器！');
        }
    }
    else if (str == 'Bigdata') {
        window.location = "/BigData/ChampionTrend";
    }
    else if (str == 'lofter') {
        window.open("http://lingminme.lofter.com/");
    }
    else if (str == 'icp') {
        window.open("http://www.beian.gov.cn/portal/registerSystemInfo?recordcode=11010602006016");
    }
    else if (str == 'home') {
        window.location = '/Home/Index';
    }
    else if (str == "aero") {
        window.location = '/BigData/AeroTrend';
    }
    else if (str == 'herolist') {
        window.location = '/BigData/HeroList';
    }
    else if (str == "freehero") {
        window.location = '/BigData/FreeHero';
    }
    else if (str == 'email') {
        window.open('mailto:kid--l@hotmail.com');
    }
    else if (str == 'pay') {
        toastr.options = {
            "positionClass": "toast-bottom-full-width",
            "timeOut": "300000",
            "closeButton": true
        };
        toastr.success('<img src="/Image/pay/zhifu.png" style="width:500px;height:311px" />');
    }
    else if (str == 'faq') {
        window.open("/Home/Faq");
    }
}

//获取浏览器类型
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

//排序函数
function JsonSort(json, key) {
    for (var j = 1, jl = json.length; j < jl; j++) {
        var temp = json[j],
            val = temp[key],
            i = j - 1;
        while (i >= 0 && json[i][key] > val) {
            json[i + 1] = json[i];
            i = i - 1;
        }
        json[i + 1] = temp;

    }
    return json;
}

//保留小数
function toDecimal2(x) {
    var f = parseFloat(x);
    if (isNaN(f)) {
        return false;
    }
    var f = Math.round(x * 100) / 100;
    var s = f.toString();
    var rs = s.indexOf('.');
    if (rs < 0) {
        rs = s.length;
        s += '.';
    }
    while (s.length <= rs + 2) {
        s += '0';
    }
    return s;
}

//格式化字符串
String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g, function (s, i) {
        return args[i];
    });
}


//去除Unicode编码
function replace_unicode(data) {
    data = data.replace(/\\n/g, "\\n")
               .replace(/\\'/g, "\\'")
               .replace(/\\"/g, '\\"')
               .replace(/\\&/g, "\\&")
               .replace(/\\r/g, "\\r")
               .replace(/\\t/g, "\\t")
               .replace(/\\b/g, "\\b")
               .replace(/\\f/g, "\\f");
    data = data.replace(/[\u0000-\u0019]+/g, "");
    return data;
}


function create_hero_title_cname_dic() {
    var dic = new Array();
    dic['黑暗之女'] = 'Annie';
    dic['狂战士'] = 'Olaf';
    dic['正义巨像'] = 'Galio';
    dic['卡牌大师'] = 'TwistedFate';
    dic['德邦总管'] = 'XinZhao';
    dic['无畏战车'] = 'Urgot';
    dic['诡术妖姬'] = 'Leblanc';
    dic['猩红收割者'] = 'Vladimir';
    dic['末日使者'] = 'FiddleSticks';
    dic['审判天使'] = 'Kayle';
    dic['无极剑圣'] = 'MasterYi';
    dic['牛头酋长'] = 'Alistar';
    dic['符文法师'] = 'Ryze';
    dic['亡灵战神'] = 'Sion';
    dic['战争女神'] = 'Sivir';
    dic['众星之子'] = 'Soraka';
    dic['迅捷斥候'] = 'Teemo';
    dic['麦林炮手'] = 'Tristana';
    dic['祖安怒兽'] = 'Warwick';
    dic['雪人骑士'] = 'Nunu';
    dic['赏金猎人'] = 'MissFortune';
    dic['寒冰射手'] = 'Ashe';
    dic['蛮族之王'] = 'Tryndamere';
    dic['武器大师'] = 'Jax';
    dic['堕落天使'] = 'Morgana';
    dic['时光守护者'] = 'Zilean';
    dic['炼金术士'] = 'Singed';
    dic['寡妇制造者'] = 'Evelynn';
    dic['瘟疫之源'] = 'Twitch';
    dic['死亡颂唱者'] = 'Karthus';
    dic['虚空恐惧'] = 'Chogath';
    dic['殇之木乃伊'] = 'Amumu';
    dic['披甲龙龟'] = 'Rammus';
    dic['冰晶凤凰'] = 'Anivia';
    dic['恶魔小丑'] = 'Shaco';
    dic['祖安狂人'] = 'DrMundo';
    dic['琴瑟仙女'] = 'Sona';
    dic['虚空行者'] = 'Kassadin';
    dic['刀锋意志'] = 'Irelia';
    dic['风暴之怒'] = 'Janna';
    dic['海洋之灾'] = 'Gangplank';
    dic['英勇投弹手'] = 'Corki';
    dic['天启者'] = 'Karma';
    dic['瓦洛兰之盾'] = 'Taric';
    dic['邪恶小法师'] = 'Veigar';
    dic['巨魔之王'] = 'Trundle';
    dic['策士统领'] = 'Swain';
    dic['皮城女警'] = 'Caitlyn';
    dic['蒸汽机器人'] = 'Blitzcrank';
    dic['熔岩巨兽'] = 'Malphite';
    dic['不祥之刃'] = 'Katarina';
    dic['永恒梦魇'] = 'Nocturne';
    dic['扭曲树精'] = 'Maokai';
    dic['荒漠屠夫'] = 'Renekton';
    dic['德玛西亚皇子'] = 'JarvanIV';
    dic['蜘蛛女皇'] = 'Elise';
    dic['发条魔灵'] = 'Orianna';
    dic['齐天大圣'] = 'MonkeyKing';
    dic['复仇焰魂'] = 'Brand';
    dic['盲僧'] = 'LeeSin';
    dic['暗夜猎手'] = 'Vayne';
    dic['机械公敌'] = 'Rumble';
    dic['魔蛇之拥'] = 'Cassiopeia';
    dic['水晶先锋'] = 'Skarner';
    dic['大发明家'] = 'Heimerdinger';
    dic['沙漠死神'] = 'Nasus';
    dic['狂野女猎手'] = 'Nidalee';
    dic['兽灵行者'] = 'Udyr';
    dic['圣锤之毅'] = 'Poppy';
    dic['酒桶'] = 'Gragas';
    dic['战争之王'] = 'Pantheon';
    dic['探险家'] = 'Ezreal';
    dic['铁铠冥魂'] = 'Mordekaiser';
    dic['牧魂人'] = 'Yorick';
    dic['暗影之拳'] = 'Akali';
    dic['狂暴之心'] = 'Kennen';
    dic['德玛西亚之力'] = 'Garen';
    dic['曙光女神'] = 'Leona';
    dic['虚空先知'] = 'Malzahar';
    dic['刀锋之影'] = 'Talon';
    dic['放逐之刃'] = 'Riven';
    dic['深渊巨口'] = 'KogMaw';
    dic['暮光之眼'] = 'Shen';
    dic['光辉女郎'] = 'Lux';
    dic['远古巫灵'] = 'Xerath';
    dic['龙血武姬'] = 'Shyvana';
    dic['九尾妖狐'] = 'Ahri';
    dic['法外狂徒'] = 'Graves';
    dic['潮汐海灵'] = 'Fizz';
    dic['雷霆咆哮'] = 'Volibear';
    dic['傲之追猎者'] = 'Rengar';
    dic['惩戒之箭'] = 'Varus';
    dic['深海泰坦'] = 'Nautilus';
    dic['机械先驱'] = 'Viktor';
    dic['北地之怒'] = 'Sejuani';
    dic['无双剑姬'] = 'Fiora';
    dic['爆破鬼才'] = 'Ziggs';
    dic['仙灵女巫'] = 'Lulu';
    dic['荣耀行刑官'] = 'Draven';
    dic['战争之影'] = 'Hecarim';
    dic['虚空掠夺者'] = 'Khazix';
    dic['诺克萨斯之手'] = 'Darius';
    dic['未来守护者'] = 'Jayce';
    dic['冰霜女巫'] = 'Lissandra';
    dic['皎月女神'] = 'Diana';
    dic['德玛西亚之翼'] = 'Quinn';
    dic['暗黑元首'] = 'Syndra';
    dic['铸星龙王'] = 'AurelionSol';
    dic['影流之镰'] = 'Kayn';
    dic['荆棘之兴'] = 'Zyra';
    dic['迷失之牙'] = 'Gnar';
    dic['生化魔人'] = 'Zac';
    dic['疾风剑豪'] = 'Yasuo';
    dic['虚空之眼'] = 'Velkoz';
    dic['岩雀'] = 'Taliyah';
    dic['青钢影'] = 'Camille';
    dic['弗雷尔卓德之心'] = 'Braum';
    dic['戏命师'] = 'Jhin';
    dic['永猎双子'] = 'Kindred';
    dic['暴走萝莉'] = 'Jinx';
    dic['河流之王'] = 'TahmKench';
    dic['圣枪游侠'] = 'Lucian';
    dic['影流之主'] = 'Zed';
    dic['暴怒骑士'] = 'Kled';
    dic['时间刺客'] = 'Ekko';
    dic['皮城执法官'] = 'Vi';
    dic['暗裔剑魔'] = 'Aatrox';
    dic['唤潮鲛姬'] = 'Nami';
    dic['沙漠皇帝'] = 'Azir';
    dic['魂锁典狱长'] = 'Thresh';
    dic['海兽祭司'] = 'Illaoi';
    dic['虚空遁地兽'] = 'RekSai';
    dic['翠神'] = 'Ivern';
    dic['复仇之矛'] = 'Kalista';
    dic['星界游神'] = 'Bard';
    dic['幻翎'] = 'Rakan';
    dic['逆羽'] = 'Xayah';
    dic['山隐之焰'] = 'Ornn';
    return dic;
}

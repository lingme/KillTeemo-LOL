$(function () {
    var name = $(document).attr("title");
    $.ajax({
        'async': true,
        'url': '/BigData/Get_Hero_Info',
        'type': 'post',
        'datatype': 'json',
        'data': { Hero_Ename: name },
        success: function (data) {
            var Json_ob = JSON.parse(replace_unicode(data));
            create_table(Json_ob);
        }
    });
});


function create_table(Json) {
    $("#top_title").text(' ' + Json[0].title);
    $("#hero_name").text(Json[0].cname);
    $("#hero_birthday").text(' ' + Json[0].hero_birthday.replace('-', '·').replace('-','·'));

    var stat_list = Json[0].difficulty.split("|");
    $("#shengcunnengli_p").text(Math.floor(parseInt(stat_list[0].replace('%', '')) / 10));
    $("#shengcunnengli_pro").css({ "width": stat_list[0] });

    $("#wuli_p").text(parseInt(Math.floor(stat_list[1].replace('%', '')) / 10));
    $("#wuli_pro").css({ "width": stat_list[1] });

    $("#mofa_p").text(parseInt(Math.floor(stat_list[2].replace('%', '')) / 10));
    $("#mofa_pro").css({ "width": stat_list[2] });

    $("#nandu_p").text(parseInt(Math.floor(stat_list[3].replace('%', '')) / 10));
    $("#nandu_pro").css({ "width": stat_list[3] });

    var point_list = Json[0].AddPoint.split("|");
    var p_q = "", p_w = "", p_e = "", p_r = "" , result = "";
    for (var i = 0; i < point_list.length; i++) {
        if (point_list[i] == "Q") {
            p_q += '<p class="index_p">Q</p>'
            p_w += '<p class="index_p"> </p>'
            p_e += '<p class="index_p"> </p>'
            p_r += '<p class="index_p"> </p>'
        }
        else if (point_list[i] == 'W') {
            p_q += '<p class="index_p"> </p>'
            p_w += '<p class="index_p">W</p>'
            p_e += '<p class="index_p"> </p>'
            p_r += '<p class="index_p"> </p>'
        }
        else if (point_list[i] == 'E') {
            p_q += '<p class="index_p"> </p>'
            p_w += '<p class="index_p"> </p>'
            p_e += '<p class="index_p">E</p>'
            p_r += '<p class="index_p"> </p>'
        }
        else if (point_list[i] == 'R') {
            p_q += '<p class="index_p"> </p>'
            p_w += '<p class="index_p"> </p>'
            p_e += '<p class="index_p"> </p>'
            p_r += '<p class="index_p">R</p>'
        }
    }
    $("#q_box").empty().html(p_q);
    $("#w_box").empty().html(p_w);
    $("#e_box").empty().html(p_e);
    $("#r_box").empty().html(p_r);
    
    point_list = Json[0].hero_status.split("|");
    for (var i = 0; i < point_list.length; i++) {
        result += '<img class="item_box" src="{0}" />'.format(point_list[i]);
    }
    $("#hero_status").empty().html(result);
    result = "";

    point_list = Json[0].hero_Metaphase.split("|");
    for (var i = 0; i < point_list.length; i++) {
        result += '<img class="item_box" src="{0}" />'.format(point_list[i]);
    }
    $("#hero_Metaphase").empty().html(result);
    result = "";

    point_list = Json[0].hero_Wind.split("|");
    for (var i = 0; i < point_list.length; i++) {
        result += '<img class="item_box" src="{0}" />'.format(point_list[i]);
    }
    $("#hero_Wind").empty().html(result);
    result = "";

    point_list = Json[0].hero_Bad.split("|");
    for (var i = 0; i < point_list.length; i++) {
        result += '<img class="item_box" src="{0}" />'.format(point_list[i]);
    }
    $("#hero_Bad").empty().html(result);
    result = "";

    point_list = Json[0].CoreInstallation.split("*");
    for (var i = 0; i < point_list.length; i++) {
        var item_list = point_list[i].split("|");
        result += '<div class="hexing_item_img_div"><img class="hexing_item_img" src="{0}" /><p class="hexing_item_p">{1}</p></div>'.format(item_list[0], item_list[2]);
    }
    $(".hexing_item_div").empty().html(result);
    result = "";

    point_list = Json[0].SummonerSkills.split("*");
    for (var i = 0; i < point_list.length; i++) {
        var item_list = point_list[i].split("|");
        result += '<div class="hexing_item_img_div"><img class="hexing_item_img" src="{0}" /><p class="hexing_item_p">{1}</p></div>'.format(item_list[0], item_list[2]);
    }
    $(".hexingjineng_item_div").empty().html(result);
    result = "";

    point_list = Json[0].Restraint.split("*");
    for (var i = 0; i < point_list.length; i++) {
        var item_list = point_list[i].split("|");
        result += '<div class="hexing_item_img_div"><img class="hexing_item_img" src="{0}" /><p class="hexing_item_p">{1}</p></div>'.format(item_list[0], item_list[1]);
    }
    $(".kezhi").empty().html(result);
    result = "";

    point_list = Json[0].Restrained.split("*");
    for (var i = 0; i < point_list.length; i++) {
        var item_list = point_list[i].split("|");
        result += '<div class="hexing_item_img_div"><img class="hexing_item_img" src="{0}" /><p class="hexing_item_p">{1}</p></div>'.format(item_list[0], item_list[1]);
    }
    $(".beikezhi").empty().html(result);
    result = "";
}
$(function () {
    var name = $(document).attr("title");
    $.ajax({
        'async': true,
        'url': '/BigData/Get_Free_Hero',
        'type': 'post',
        'datatype': 'json',
        success: function (data) {
            var Json_ob = JSON.parse(replace_unicode(data));
            create_table(Json_ob);
        }
    });
});


function create_table(Json) {
    var result = "";
    var dic_name = create_hero_title_cname_dic();
    for (var i = 0 ; i < Json["free"].length; i++) {
        result += '<div class="box_div"><img id="{0}" onclick="img_clik(this)" class="img_box" src="{1}" /><p class="img_p">{2}</p></div>'.format(dic_name[Json["free"][i].name],Json["free"][i].img, ' ' + Json["free"][i].name);
    }
    $("#free_box_div").empty().html(result);
    $(".content").mCustomScrollbar("update");
}

function img_clik(obj) {
    window.open('/BigData/HeroInfo?heroname=' + obj.id);
}

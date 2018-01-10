function get_ajax(hero_type) {
    $.ajax({
        'async':true,
        'url': '/BigData/Get_Hero_List',
        'type':'post',
        'datatype': 'json',
        'data': { Hero_type: hero_type },
        success: function (data) {
            var json_str = JSON.parse(replace_unicode(data));
            create_table(json_str);
        }
    });
}


function create_table(data) {
    var result = '';
    for (var i = 0 ; i < data.length; i++) {
        result += '<div class="anti_div" ><div class="hero_icon_box"><img id="{0}" onclick="img_clik(this)" src="/Image/heroicon/{1}"  class="img_anti" /></div><p class="hero_name_p">{2}</p></div>'.format(data[i].Ename, data[i].Pic, data[i].Title);
    }

    $("#table_hero").empty().html(result);
    $(".content").mCustomScrollbar("update");
}


$(function () {
    get_ajax('all');
});



function img_clik(obj) {
    window.open('/BigData/HeroInfo?heroname=' + obj.id);
}
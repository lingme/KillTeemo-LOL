function getdata(order_name) {
    ajax_col(order_name);
}


function ajax_col(order_name) {
    $.ajax({
        'type': 'post',
        'asnyc': true,
        'url': '/BigData/Get_Aero_Num',
        'datatype': 'json',
        'data': {},
        success: function (data) {
            var jsr = JSON.parse(replace_unicode(data));
            create_table(jsr,order_name);
        }
    });
}

function create_table(json_list, order_name) {

    if (order_name != 'Num') {
        JsonSort(json_list, order_name);
        json_list.reverse();
    }

    var reust = '';
    var num = 0;
    var avg_men = 0;
    var avg_women = 0;
    for (var i = 0; i < json_list.length ; i++) {
        var table_str = '<div class="box_div_anti">   <div class="box_div_anti_top"><div class="div_paiming"> <p class="paiming_p" >{0}</p></div><div class="icon_div_box" > <img src="/Image/aeroicon/{1}.png"  class="img_img" /> <p class="aero_name" >{2}</p></div><div class="pro_box" > <p class="ptin_P" >{3}</p></div><div class="pro_box"> <div class="pro_anti" >  <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: {4}%;background-color:#FFFFFF"></div> </div> <p class="text_p" >{5}%</p></div><div class="pro_box"> <div class="pro_anti" >  <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: {6}%;background-color:#FFFFFF"></div> </div> <p class="text_p">{7}%&nbsp;/&nbsp;{8}%</p></div>   </div><img src="/Image/champion_trend_img/win.png" />  </div>'.format(i + 1, i + 1, json_list[i].AeroName, json_list[i].Num, json_list[i].Mode, toDecimal2(json_list[i].Mode), json_list[i].Man, json_list[i].Man, json_list[i].Women);
        reust += table_str;
        num += json_list[i].Num;
        avg_men += json_list[i].Man;
        avg_women += json_list[i].Women;
    }
    $("#aero_all_num").text(' '+ parseInt(num.toString()).toLocaleString());
    $("#aero_life_num").text(' ' + parseInt((num * 0.3).toString()).toLocaleString());
    $("#men_women").text(' {0}% · {1}%'.format(parseInt(avg_men / json_list.length), parseInt(avg_women / json_list.length)));
    $("#table_hero").empty().html(reust);
    $(".content").mCustomScrollbar("update");
}


$(function () {
    getdata('Num');
});
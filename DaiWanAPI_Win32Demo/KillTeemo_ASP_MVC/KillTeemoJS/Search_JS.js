function carete_table(Json) {
    var result = '<div style="width:100%;height:65px;position:relative"><img src="/Image/champion_trend_img/win.png" style="height:19px;left:0px;position:absolute;top:0px;" /><div style="width:100%;height:30px;left:0px;top:23px;position:relative"><div style="float:left;width:13%;height:30px"></div><div style="float:left;width:17%;height:30px"><p style="color:#f0e6d2;font-size:14px;text-align:center">召&nbsp;唤&nbsp;师&nbsp;</p></div><div style="float:left;width:25%;height:30px"><p class="head_P" >大&nbsp;区&nbsp;</p></div><div style="float:left;width:15%;height:30px"><p class="head_P" >等&nbsp;级</p></div><div style="float:left;width:15%;height:30px"><p class="head_P" >段&nbsp;位</p></div><div style="float:left;width:15%;height:30px"><p class="head_P" >胜&nbsp;点</p></div></div><img src="/Image/champion_trend_img/win.png" style="height:19px;left:0px;position:absolute;top:45px;" /></div>';
    for(var i = 0 ; i < Json.length ; i++)
    {
        result += '<div id="{0}" onclick="link_player(this)" class="anti_div" ><div class="anti_div_div" > <img src="{1}" class="img_box"/> <p class="p_one">{2}</p> <p class="p_two" >{3}</p> <p class="p_three">{4}</p> <p class="p_four">{5}</p> <p class="p_five" >{6}</p></div><div class="img_line"><img src="/Image/champion_trend_img/win.png" /></div></div>'.format(Json[i].Ency_qquin,  Json[i].icon_src, Json[i].name, Json[i].area_name, 'Lv.' + Json[i].level, Json[i].tierqueue, Json[i].win_point);
    }

    $("#table_div").empty().html(result);
    $("#ANII").text(' ' + Json.length + "个召唤师匹配");
    $(".content").mCustomScrollbar("update");
}



function link_player(obj) {
    alert(obj.id);
}

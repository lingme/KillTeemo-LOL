function create_table(data, order_name) {
    if (order_name != 'Win' )
    {
        JsonSort(data, order_name);
        data.reverse();
    }
    var reust = '';
    for (var i = 0; i < data.length ; i++) {
        var table_str = '<div class="all_box_div" ><div class="all_box_div_top"><div class="tianchong_kong"> <p class="pai_ming">{0}</p></div><div class="heroname_and_heroicon"><img class="hero_icon" onclick="img_clik(this)" src="/Image/heroicon/{1}"/><p class="hero_name" >{2}</p></div><div class="progress_bar_top_div" ><div class="pro_div" ><div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: {3}%;background-color:#FFFFFF"></div></div><p class="pro_text_p" class="pro_text_p">{4}%</p></div><div class="progress_bar_top_div"><div class="pro_div"> <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: {5}%;background-color:#FFFFFF"></div></div><p class="pro_text_p">{6}%</p></div><div class="progress_bar_top_div"><div class="pro_div"><div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: {7}%;background-color:#FFFFFF"></div></div><p class="pro_text_p">{8}%</p></div></div><img src="/Image/champion_trend_img/win.png" /></div>'.format(i + 1, data[i].HeroIcon, data[i].HeroName, data[i].Win, toDecimal2(data[i].Win), data[i].Appearance, toDecimal2(data[i].Appearance), data[i].Ban, toDecimal2(data[i].Ban));
        reust += table_str;
    }
    $("#table_hero").empty().html(reust);

    JsonSort(data, 'Win');
    data.reverse();
    reust = '<div class="win_box_div">   <img onclick="img_clik(this)" id="ban_1" src="/Image/heroicon/{0}" class="icon_one"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_2" src="/Image/heroicon/{1}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_3" src="/Image/heroicon/{2}" class="icon_three"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_4" src="/Image/heroicon/{3}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_5" src="/Image/heroicon/{4}" class="icon_one"/>  </div>'.format(data[3].HeroIcon, data[1].HeroIcon, data[0].HeroIcon, data[2].HeroIcon, data[4].HeroIcon);
    $(".win_row").empty().html(reust);

    JsonSort(data, 'Appearance');
    data.reverse();
    reust = '<div class="win_box_div">   <img onclick="img_clik(this)" id="ban_1" src="/Image/heroicon/{0}" class="icon_one"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_2" src="/Image/heroicon/{1}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_3" src="/Image/heroicon/{2}" class="icon_three"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_4" src="/Image/heroicon/{3}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_5" src="/Image/heroicon/{4}" class="icon_one"/>  </div>'.format(data[3].HeroIcon, data[1].HeroIcon, data[0].HeroIcon, data[2].HeroIcon, data[4].HeroIcon);
    $(".out_row").empty().html(reust);

    JsonSort(data, 'Ban');
    data.reverse();
    reust = '<div class="win_box_div">   <img onclick="img_clik(this)" id="ban_1" src="/Image/heroicon/{0}" class="icon_one"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_2" src="/Image/heroicon/{1}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_3" src="/Image/heroicon/{2}" class="icon_three"/>  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_4" src="/Image/heroicon/{3}" class="icon_two" />  </div>  <div class="win_box_div">   <img onclick="img_clik(this)" id="ban_5" src="/Image/heroicon/{4}" class="icon_one"/>  </div>'.format(data[3].HeroIcon, data[1].HeroIcon, data[0].HeroIcon, data[2].HeroIcon, data[4].HeroIcon);
    $(".ban_row").empty().html(reust);

    $(".content").mCustomScrollbar("update");
}

function order_click(ord_name) {
    get_data(get_tier_queue(), ord_name);
}

function img_clik(obj) {
    var arr = obj.src.split('/');
    var my = arr[arr.length - 1].replace("_square_0.png", "");
    window.open('/BigData/HeroInfo?heroname=' + my);
}

function get_tier_queue() {
    return 't' + $("#tier_select").val() + 'p' + $("#queue_select").val();
}

$(function () {
    get_data(get_tier_queue(), 'Win');
});

function select_chang(){
    get_data(get_tier_queue(),'Win');
}

function get_data(tierqueue,order_name) {
    $.ajax({
        'async': true,
        'url': '/BigData/Get_Champion_Trend',
        "type": "post",
        'datatype':'json',
        'data': { TierQueue: tierqueue },
        success: function (data) {
            var jsr = JSON.parse(replace_unicode(data));
            create_table(jsr, order_name);
        }
    });
}



//输入框获得焦点事件
function OnFocusClick() {
    $("#SerBox").animate({ top: '50px' });
    $("#mid_kill_logo").animate({ opacity: "1" });
    $("#Home_Snow_Div").css("opacity", "0.3");
    $("#bg_div").animate({ opacity: "0" }, "3000");
}

//输入框失去焦点事件
function OnBlurClick() {
    $("#SerBox").animate({ top: '0px' });
    $("#mid_kill_logo").animate({ opacity: "0.01" });
    $("#Home_Snow_Div").css("opacity", "0.6");
    $("#bg_div").animate({ opacity: "1" }, "3000");
}


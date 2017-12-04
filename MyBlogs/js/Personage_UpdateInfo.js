//设置页面中间布局高度
function SetCenterHeight() {
	var height = document.documentElement.clientHeight - 195;
	var $center = $("center");
	if(height < 500) {
		height = 600;
	}
	$center.height(height);
	window.onresize = function() {
		SetCenterHeight();
	}
}
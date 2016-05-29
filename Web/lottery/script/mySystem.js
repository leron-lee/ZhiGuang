///-------------------------------///


$.fn.extend({
	luckDraw:function(data){
		var anc = $(this); //祖父元素
		var list = anc.children("li");
		var click; //点击对象
		var lineNumber; //几行 3
		var	listNumber; //几列 4
		var thisWidth;
		var thisHeight;
		if(data.line==null){return;}else{lineNumber=data.line;}
		if(data.list==null){return;}else{listNumber=data.list;}
		if(data.width==null){return;}else{thisWidth=data.width;}
		if(data.height==null){return;}else{thisHeight=data.height;}
		if(data.click==null){return;}else{click=data.click;}

		///---初始化
		anc.css({
			width:thisWidth*listNumber,
			height:thisHeight*lineNumber,
			position:"relative"
		});
		list.css({
			width:thisWidth,
			height:thisHeight,
			position:"absolute"
		});
		
		var all = listNumber*lineNumber - (lineNumber-2)*(listNumber-2)  //应该有的总数
		if(all>list.length){ //如果实际方块小于应该有的总数
			for(var i=0;i<(all-list.length);i++){
				anc.append("<li>"+all+"</li>");
			}
		}
		
		list = anc.children("li");
		list.css({
			width:thisWidth,
			height:thisHeight,
			position:"absolute"
		});

		list.each(function(index){
			if(index < listNumber){  //---小于listNumber列
				$(this).css({
					left:index%listNumber*thisWidth
				});
			}
			else if(index >= listNumber && index < listNumber+lineNumber-2){
				$(this).css({
					top:(index+1)%listNumber*thisHeight,
					right:0
				});
			}
			else if(index >= listNumber+lineNumber-2 && index < all-lineNumber+2){
				$(this).css({
					bottom:0,
					right:(index-1)%listNumber*thisWidth
				});
			}else{
				/*
				*/
				$(this).css({
					bottom:(index-5)%listNumber*thisHeight,
					left:0
				});
			}
			if(index+1 > all){
				$(this).remove();
			}
		});
		var ix = 0;
		var speed = 500;
		var Countdown = 1000; //倒计时
		var isRun = false;
		var dgTime = 200;
		var raff=0;

		$(click).click(function(){
			if(isRun){
				return;
			}else{
				var stime = Raffle();
				raff=stime;
                		dgTime += stime * 10 + 80;

                		if (stime == "支付失败") {
					layer_pic("帐号异常请重新登录");
                		}
                		else if (stime == "余额不足") {
					layer_pic("余额不足");
                		}
                		else if (stime == "活动结束") {
					layer_pic("活动结束或抽奖次数不足");
                		}
                		else if (stime == "") {
					layer_pic("您不是普通会员或未登录");
                		}
                		else if (stime == "1" ||stime == "2"||stime == "3"||stime == "4"||stime == "5"||stime == "6"||stime == "7"||stime == "8"||stime == "9"||stime == "10"||stime == "11"||stime == "12") {
                    			speedUp();
                		}
                		else {
                    			layer_pic("帐号异常请重新登录");
                		}
			}
		});

        function Raffle() {
            var v = "";
            $.ajax({
                async: false,
                url: "/api/RaffleHandler.ashx",
                success: function (d) {
                    v = d;
                },
                error: function () {
                    v = "支付失败";
                }
            });
            return v;
        }
		function speedUp(){ //加速
			isRun = true;
			list.removeClass("adcls");
			list.eq(ix).addClass("adcls");
			ix++;
			init(ix);
			speed -= 50;
			if(speed == 100){
				clearTimeout(stop);
				uniform();
			}else{
				var stop = setTimeout(speedUp,speed);
			}
		}
		function uniform(){ //匀速
			list.removeClass("adcls");
			list.eq(ix).addClass("adcls");
			ix++;
			init(ix);
			Countdown -= 50 ;
			if(Countdown == 0){
				clearTimeout(stop);
				speedDown();
			}else{
				var stop = setTimeout(uniform,speed);
			}
		}
		function speedDown(){ //减速
			list.removeClass("adcls");
			list.eq(ix).addClass("adcls");
			ix++;
			init(ix);
			speed += 10;
			if(speed == dgTime+20){
				clearTimeout(stop);
				end();
			}else{
				var stop = setTimeout(speedDown,speed);
			}
		} 
		function end(){
			if(ix == 0){
				ix = 12;
			}
			//$('.jieguo').html('结果：恭喜 <span> '+ix+' </span> 号中奖');  ///可注释掉
if(raff=="1") layer_pic("恭喜您抽中IPhone 6S 一台");
if(raff=="2") layer_pic("恭喜您抽中10易券");
if(raff=="4") layer_pic("恭喜您抽中20易券");
if(raff=="6") layer_pic("恭喜您抽中50易券");
if(raff=="7") layer_pic("恭喜您抽中滚筒洗衣机一台");
if(raff=="8") layer_pic("恭喜您抽中100易券");
if(raff=="9") layer_pic("恭喜您抽中美的微波炉一台");
if(raff=="11") layer_pic("恭喜您抽中200易券");
if(raff=="12") layer_pic("恭喜您抽中双开门冰箱一台");
			initB();
		}
		///--归0
		function init(o){
			if(o == all){
				ix = 0;	
			}
		}
		///
		function initB(){
			ix = 0;
			dgTime = 200;
			speed = 500;
			Countdown = 1000;
			isRun = false;
		}
	}

});   
$(function(){
	$('.cj').luckDraw({
		width:109, //宽
		height:114, //高
		line:3, //几行
		list:5, //几列
		click:".actionCj" //点击对象
	});
});

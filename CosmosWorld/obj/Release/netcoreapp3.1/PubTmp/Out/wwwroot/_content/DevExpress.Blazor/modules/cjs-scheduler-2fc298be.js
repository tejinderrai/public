DxBlazorInternal.define("cjs-scheduler-2fc298be.js",(function(t,e,n){var i=t("./cjs-chunk-c5286524.js"),o=t("./cjs-dom-utils-c4472fdd.js"),r=t("./cjs-chunk-fc814f01.js"),a=t("./cjs-chunk-2cdecb19.js"),l=t("./cjs-chunk-a0f3c48f.js"),s={showCallout:!0,showTitle:!1,position:"right",className:"",classNames:{sysClassName:"dx-hint",contentElementClassName:"dxh-content",calloutElementClassName:"arrow",titleElementClassName:"dxh-title"},allowFlip:!0,allowShift:!0,offset:4};function c(t,e,n){n||(n=s),e.style.visibility="hidden",e.style.display="block",function(t,e){var n=o.getAbsoluteX(t),i=o.getAbsoluteY(t);o.setAbsoluteX(e,n),o.setAbsoluteY(e,i)}(t,e),u.updatePosition(t,e,n),e.style.visibility=""}var u=function(){function t(t){return"bs-popover-"+t.toLowerCase()}function e(e,n,i){var r=p.set(e,n,i);!function(e,n,i){var r=t(n),a=t(i);o.removeClassNameFromElement(e,r),o.addClassNameToElement(e,a)}(n,i.position,r.flipPosition),function(t,e,n){var i=u.getCalloutElement(t,e.classNames);if(i){var o,r=!("left"===(o=e.position)||"right"===o),a=r?t.offsetWidth:t.offsetHeight,l=a/2-(r?n.x:n.y);l=function(t,e){var n={min:15,max:e-15},i=t<n.min,o=t>n.max;o&&(t=n.max);i&&(t=n.min);t+="px",i&&o&&(t="50%");return t}(l,a),i.style[r?"left":"top"]=l}}(n,i,r.shift)}return{getCalloutElement:function(t,e){return t?t.getElementsByClassName(e.calloutElementClassName)[0]:null},updatePosition:function(t,n,i){var o=10,r=!1;do{var a={w:n.offsetWidth,h:n.offsetHeight};e(t,n,i),r=a.w!==n.offsetWidth||a.h!==n.offsetHeight,o--}while(r&&o>0)}}}();function f(t,e,n){this.targetElement=t,this.hintElement=e,this.options=n,this.position=n.position,this.calloutSize={width:0,height:0};var r=u.getCalloutElement(e,n.classNames);function a(t,e,n,r,a){this.location=0,this.screen={min:0,max:0},this.screen.min=a?o.getDocumentScrollLeft():o.getDocumentScrollTop();var l=i.Browser.WebKitTouchUI?window.innerWidth:o.getDocumentClientWidth();this.screen.max=this.screen.min+(a?l:o.getDocumentClientHeight()),this.target={min:0,max:0},this.target.min=a?o.getAbsoluteX(t):o.getAbsoluteY(t),this.target.max=this.target.min+(a?t.offsetWidth:t.offsetHeight),this.hintSize=a?e.offsetWidth:e.offsetHeight}r&&(this.calloutSize.width=r.offsetWidth,this.calloutSize.height=r.offsetHeight),this.horizontal=new a(t,e,n,this.calloutSize,!0),this.vertical=new a(t,e,n,this.calloutSize,!1)}var p=function(){function t(t,i,o){var r=new f(t,i,o),a=e(r.position);o.allowFlip&&(a.horizontal?r.position=d.flipPositionIfRequired(r.horizontal,r.position):a.vertical&&(r.position=d.flipPositionIfRequired(r.vertical,r.position)));var l=function(t){return n(t.position,{width:t.horizontal.target.max-t.horizontal.target.min,height:t.vertical.target.max-t.vertical.target.min},{width:t.horizontal.hintSize,height:t.vertical.hintSize},t.calloutSize)}(r),s={x:0,y:0};return o.allowShift&&(s.x=h.getShift(r.horizontal,a,l.x,0,!0),s.y=h.getShift(r.vertical,a,l.y,0,!1)),{location:{x:l.x+s.x,y:l.y+s.y},shift:s,flipPosition:r.position}}function e(t){return{vertical:"bottom"===t||"top"===t,horizontal:"right"===t||"left"===t}}function n(t,e,n,i){var o={x:0,y:0};return"top"===t?o.y-=n.height+i.height:"bottom"===t?o.y+=e.height+i.height:"left"===t?o.x-=n.width+i.width:"right"===t&&(o.x+=e.width+i.width),"top"!==t&&"bottom"!==t||(o.x+=e.width/2-n.width/2),"left"!==t&&"right"!==t||(o.y+=e.height/2-n.height/2),o}return{set:function(n,i,r){var a=t(n,i,r),l={x:0,y:0},s=e(a.flipPosition);s.horizontal&&(l.x=r.offset*a.location.x/Math.abs(a.location.x)),s.vertical&&(l.y=r.offset*a.location.y/Math.abs(a.location.y));var c=void 0!==r.x?r.x:o.getAbsoluteX(n)+a.location.x+l.x,u=void 0!==r.y?r.y:o.getAbsoluteY(n)+a.location.y+l.y;return o.setAbsoluteX(i,c),o.setAbsoluteY(i,u),{flipPosition:a.flipPosition,shift:{x:a.shift.x,y:a.shift.y}}},getNotShiftedOffsetCore:n}}(),d={flipPositionIfRequired:function(t,e){return this.ensureFlipCore(t.screen,t.target,t.hintSize,e)},getFlipPosition:function(t){return"bottom"===t?"top":"top"===t?"bottom":"right"===t?"left":"left"===t?"right":t},ensureFlipCore:function(t,e,n,i){var o="bottom"===i||"right"===i,r="top"===i||"left"===i,a=e.min-n-t.min;e.min-n>t.max&&(a=-1);var l=t.max-(e.max+n);e.max+n<t.min&&(l=-1);var s=a>=0,c=l>=0;return s||c?r&&s||o&&c?i:r&&!s&&a<l||o&&!c&&l<a?this.getFlipPosition(i):i:i}},h={getShift:function(t,e,n,i,o){var r=0;return!(e.horizontal&&o||e.vertical&&!o)&&(r=this.getShiftCore(t.screen,t.target,t.hintSize,n,i)),r},getShiftCore:function(t,e,n,i,o){if(e.max<t.min+o||e.min>t.max-o)return 0;var r=e.min+i,a=e.min+i+n,l=r<t.min&&a>t.min,s=a>t.max&&r<t.max;return l&&!s?t.min-r:s&&!l?t.max-n-r:0}},m="none",g="drag",v="resizeTop",y="resizeBottom",C="resizeSelection";function A(t,e,n,i,u){if(t&&(t.appointmentToolTipElement&&r.disposeEvents(t.appointmentToolTipElement),t.dropDownDateNavigatorElement&&r.disposeEvents(t.dropDownDateNavigatorElement),t.elementContentSizeSubscription&&o.unsubscribeElement(t.elementContentSizeSubscription)),t=o.ensureElement(t)){if(t.dropDownDateNavigatorElement=o.ensureElement(e),t.appointmentToolTipElement=o.ensureElement(n),t.appointmentEditForm=o.ensureElement(i),t.mouseMoveHandlerState||(t.mouseMoveHandlerState=m),t.appointmentToolTipElement){var f=T.getSelectedAppointment(t);if(f){var p=function(t,e,n){var i=t.getBoundingClientRect(),r=n.getBoundingClientRect();s.position=o.elementHasCssClass(e,"dxsc-tooltip")?i.right-r.right>370?"right":r.left-i.left>370?"left":r.top-i.top>370?"top":"bottom":i.right-r.right>450?"right":r.left-i.left>450?"left":"auto";return s}(t,t.appointmentToolTipElement,f);c(f,t.appointmentToolTipElement,p)}}var d=new I(t,"dxbs-sc-all-day-area"),h=new I(t,"dxbs-sc-time-cell"),A=T.getHorizontalAppointments(t),S=T.getVerticalAppointments(t);if(t.appointmentInfos=D.createItems(A,d,h),t.appointmentInfos=t.appointmentInfos.concat(D.createItems(S,d,h)),t.skipCalculateAllAppointments){var H=function(t){for(var e=[],n=0,i=void 0;i=t[n];n++)o.elementHasCssClass(i,"dxbs-apt-edited")&&e.push(i);return e};return A=H(A),S=H(S),w(A,S,!1),Promise.resolve("ok")}return!function(t,e,n,i){a.LongTabEventHelper.attachEventToElement(t,"mousedown",W),a.LongTabEventHelper.attachEventToElement(t,"mouseup",U),a.LongTabEventHelper.attachEventToElement(t,"mousemove",B),a.LongTabEventHelper.attachLongTabEventToElement(t,K),a.LongTabEventHelper.attachEventToElement(t,"touchstart",Y),a.LongTabEventHelper.attachEventToElement(t,"touchmove",X),a.LongTabEventHelper.attachEventToElement(t,"touchend",R),e&&(e.dateNavigatorLostFocusHandler=function(t){return j(t,e,"OnDropDownDateNavigatorLostFocus",i)},o.attachEventToElement(document,a.TouchUIHelper.touchMouseDownEventName,e.dateNavigatorLostFocusHandler),r.registerDisposableEvents(e,(function(){o.detachEventFromElement(document,a.TouchUIHelper.touchMouseDownEventName,e.dateNavigatorLostFocusHandler)})));n&&(n.toolTipLostFocusHandler=function(t){var e=T.getAppointmentContainer(t.srcElement);if(!e||!b(e))return j(t,n,"OnAppointmentToolTipLostFocus",i)},o.attachEventToElement(document,a.TouchUIHelper.touchMouseDownEventName,n.toolTipLostFocusHandler),r.registerDisposableEvents(n,(function(){o.detachEventFromElement(document,a.TouchUIHelper.touchMouseDownEventName,n.toolTipLostFocusHandler)})));t.elementContentSizeSubscription=o.subscribeElementContentSize(t,x)}(t,t.dropDownDateNavigatorElement,t.appointmentToolTipElement,u),Promise.resolve("ok")}function x(){w(A,S,!0),function(t,e){var n=(l=(new Date).getTime(),new Date(l)),i=(a=n,new Date(a.getFullYear(),a.getMonth(),a.getDate())),o=T.getTimeMarkerContainer(t),r=T.getTimeIndicatorContainer(t);var a;var l;if(!r)return;var s=function(t,e){for(var n,i=0,o=void 0;o=t[i];i++)e-T.Attr.getStart(o)>=0&&T.Attr.getEnd(o)-e>0&&(n=o);return n}(e,n);if(!s)return o.style.display="none",r.style.display="none",void 0;o.style.display="",r.style.display="";var c=Math.floor(function(t,e,n){var i=function(t,e){var n=t,i=N(e,n),o=Math.abs(i)%864e5;i<0&&(o=864e5-o);return function(t,e){var n=F(t,e),i=6e4*(n.getTimezoneOffset()-t.getTimezoneOffset());return F(n,i)}(n,o)}(n,t),o=T.Attr.getStart(e),r=T.Attr.getEnd(e),a=N(i,o);return e.offsetTop+e.offsetHeight*a/(r-o)}(n,s,i));o.style.top=c-o.offsetHeight/2+"px",o.style.width=s.offsetLeft+o.offsetHeight/2+1+"px",function(t){return t&&"none"!==t.style.display}(r)&&(r.style.top=c-1+"px",r.style.width=s.offsetWidth+"px",r.style.left=s.offsetLeft+"px")}(t,h.getTimeCells())}function w(t,e,n){d.clearObjects(),L(d.getTimeCells(),t),L(h.getTimeCells(),e),function(t){for(var e=0,n=void 0;n=t[e];e++)M(n)}(t),n&&function(t){for(var e=0,n=function(t,n){var i=0;n.intersects.forEach((function(t){i+=t.offsetHeight})),i>e&&(e=i),n.lastAppointmentTop=void 0},i=0,o=void 0;o=t[i];i++)n(0,o);t[0].style.height=e+15+"px"}(d.getTimeCells()),function(t){for(var e=0,n=void 0;n=t[e];e++)k(n)}(e)}function P(t){t&&u.invokeMethodAsync("OnAppointmentSelect",T.Attr.getAppointmentKey(t))}function q(e){return t.appointmentInfos.filter((function(t){return t.id===e}))[0]}function W(e){if(a.hasUnforcedFunction("TouchStart")||2===e.button)return 2===e.button&&o.preventEventAndBubble(e),void 0;var n=T.getAppointmentContainer(e.srcElement);n?(b(n)||P(n),o.elementHasCssClass(e.srcElement,"dxsc-top-handle")||function(t){return o.elementHasCssClass(t,"dxsc-left-handle")}(e.srcElement)?t.mouseMoveHandlerState=v:function(t){return o.elementHasCssClass(t,"dxsc-bottom-handle")}(e.srcElement)||function(t){return o.elementHasCssClass(t,"dxsc-right-handle")}(e.srcElement)?t.mouseMoveHandlerState=y:a.unforcedFunctionCall((function(){t.mouseMoveHandlerState=g}),"drag",50,!0)):t.appointmentToolTipElement||E(e.srcElement)&&(t.cellSelectionHelper=new z(t,u),t.cellSelectionHelper.start(e.srcElement),t.mouseMoveHandlerState=C)}function B(e){t.mouseMoveHandlerState!==m&&(t.throttledDrag||(t.throttledDrag=l.Timer.throttle((function(e){var n=h.findCellByPos(e.clientX,e.clientY)||d.findCellByPos(e.clientX,e.clientY);if(n)if(t.mouseMoveHandlerState===C&&t.cellSelectionHelper)t.cellSelectionHelper.resizeTo(n);else{var i=function(){var e=T.getSelectedAppointment(t);return e?q(T.Attr.getAppointmentKey(e)):null}();i&&(t.mouseMoveHandlerState!==g&&t.mouseMoveHandlerState!==v&&t.mouseMoveHandlerState!==y||(t.dragHelper||(t.dragHelper=new O(t,u),t.dragHelper.dragStart(i,n)),t.mouseMoveHandlerState===g?t.dragHelper.drag(n):t.dragHelper.resize(n,t.mouseMoveHandlerState===v)))}}),20)),t.throttledDrag(e))}function U(e){if(a.hasUnforcedFunction("TouchEnd")||2===e.button)return 2===e.button&&o.preventEventAndBubble(e),void 0;t.dragHelper||t.cellSelectionHelper?t.dragHelper?(t.dragHelper.dragEnd(),t.dragHelper=null):t.cellSelectionHelper&&(t.cellSelectionHelper.end(),t.cellSelectionHelper=null):T.getAppointmentContainer(e.srcElement)&&!a.hasUnforcedFunction("skipToolTip")&&(u.invokeMethodAsync("ShowAppointmentToolTip"),a.unforcedFunctionCall((function(){}),"skipToolTip",300)),a.clearUnforcedFunctionByKey("drag"),t.mouseMoveHandlerState=m}function Y(t){a.unforcedFunctionCall((function(){}),"TouchStart",300,!0),P(T.getAppointmentContainer(t.srcElement))}function K(e){var n=T.getAppointmentContainer(e.srcElement);if(n){var i=e.touches[0].clientX,o=e.touches[0].clientY,r=h.findCellByPos(i,o)||d.findCellByPos(i,o),a=q(T.Attr.getAppointmentKey(n));t.dragHelper=new O(t,u),t.dragHelper.dragStart(a,r)}else E(e.srcElement)&&!t.appointmentToolTipElement&&(t.cellSelectionHelper=new z(t,u),t.cellSelectionHelper.start(e.srcElement))}function X(e){if(t.dragHelper||t.cellSelectionHelper){var n=e.touches[0].clientX,i=e.touches[0].clientY,r=h.findCellByPos(n,i)||d.findCellByPos(n,i);r&&(t.dragHelper?t.dragHelper.drag(r):t.cellSelectionHelper&&t.cellSelectionHelper.resizeTo(r)),o.preventEventAndBubble(e)}}function R(t){U(t),a.unforcedFunctionCall((function(){}),"TouchEnd",300,!0)}}var T={getVerticalAppointmentsContainer:function(t){return t.querySelectorAll(".dxbs-sc-vertical-apts")[0]},getHorizontalAppointmentsContainer:function(t){return t.querySelectorAll(".dxbs-sc-horizontal-apts")[0]},getHorizontalAppointments:function(t){return t.querySelectorAll(".dxbs-sc-horizontal-apt")},getVerticalAppointments:function(t){return t.querySelectorAll(".dxbs-sc-vertical-apt")},getTimeMarkerContainer:function(t){return t.querySelectorAll(".dxbs-sc-time-marker")[0]},getTimeIndicatorContainer:function(t){return t.querySelectorAll(".dxbs-sc-time-indicator")[0]},getAppointmentContainer:function(t){return o.getParentByClassName(t,"dxbs-sc-apt")},getSelectedAppointment:function(t){return t.querySelectorAll(".dxbs-apt-selected")[0]},getEditedAppointment:function(t){return t.querySelectorAll(".dxbs-apt-edited")[0]},getCellSelectionContainer:function(t){return t.querySelectorAll(".dxsc-cell-selection")[0]},setElementDisplay:function(t,e){t.style.display=e?"":"none"},Attr:{getContainerIndex:function(t){return t.getAttribute("data-container-index")},getAppointmentFirstCellIndex:function(t){return parseInt(t.getAttribute("data-first-cell-index"))},getAppointmentLastCellIndex:function(t){return parseInt(t.getAttribute("data-last-cell-index"))},getAppointmentColumnsCount:function(t){return parseInt(t.getAttribute("data-columns-count"))},setAppointmentColumnsCount:function(t,e){t.setAttribute("data-columns-count",e)},getAppointmentColumn:function(t){return parseInt(t.getAttribute("data-column"))},setAppointmentColumn:function(t,e){t.setAttribute("data-column",e)},getAppointmentKey:function(t){return t.getAttribute("data-key")},getStart:function(t){var e=new Date(parseInt(t.getAttribute("data-start"))),n=e.getTime()+6e4*e.getTimezoneOffset()+0;return new Date(n)},getEnd:function(t){var e=new Date(parseInt(t.getAttribute("data-end"))),n=e.getTime()+6e4*e.getTimezoneOffset()+0;return new Date(n)},getDuration:function(t){return parseInt(t.getAttribute("data-duration"))},getAllDay:function(t){return""===t.getAttribute("data-allday")}}};function E(t){return o.elementHasCssClass(t,"dxbs-sc-all-day-area")||o.elementHasCssClass(t,"dxbs-sc-time-cell")}function S(t){return o.elementHasCssClass(t,"dxbs-sc-all-day-area")}function b(t){return o.elementHasCssClass(t,"dxbs-apt-selected")}function H(t){var e=T.Attr.getStart(t);return x(e,T.Attr.getEnd(t)-e)}function x(t,e){return{start:t,duration:e,isLongerOrEqualDay:e>=w.DaySpan}}var I=function(t,e){this.element=t,this.cellClassName=e};I.prototype={getContainers:function(){if(!this.containers){var t=this.element.querySelectorAll("."+this.cellClassName);this.containers={};for(var e=0,n=void 0;n=t[e];e++){var i=T.Attr.getContainerIndex(n);this.containers[i]||(this.containers[i]={cells:[]}),this.containers[i].cells.push(n)}}return this.containers},clearObjects:function(){for(var t=this.getTimeCells(),e=0,n=void 0;n=t[e];e++)this.clearObject(n)},clearObject:function(t){t.lastAppointmentTop=void 0},getTimeCells:function(){return this.timeCells||(this.timeCells=this.element.querySelectorAll("."+this.cellClassName)),this.timeCells},findCell:function(t){var e=this.getContainers();for(var n in e)if(Object.prototype.hasOwnProperty.call(e,n))for(var i=0,o=void 0;o=e[n].cells[i];i++){var r=T.Attr.getStart(o),a=T.Attr.getEnd(o);if(r-t<=0&&t-a<0)return o}return null},findStartCell:function(t){var e=this.getContainers();for(var n in e)if(Object.prototype.hasOwnProperty.call(e,n))for(var i=0,o=void 0;o=e[n].cells[i];i++){if(t-T.Attr.getStart(o)<=0)return o}return null},findEndCell:function(t){var e=this.getContainers();for(var n in e)if(Object.prototype.hasOwnProperty.call(e,n))for(var i=0,o=void 0;o=e[n].cells[i];i++){if(t-T.Attr.getEnd(o)<=0)return o}return null},findCellByPos:function(t,e){for(var n=this.getTimeCells(),i=0,o=void 0;o=n[i];i++){var r=o.getBoundingClientRect();if(r.top<=e&&e<r.bottom&&r.left<=t&&t<r.right)return o}}};var D=function(t,e,n,i){this.id=t,this.views=e,this.interval=n,this.allDay=T.Attr.getAllDay(e[0]),this.sourceView=null,this.aptCont=null,this.dateTimeViewLayout=i,this.init()};D.prototype={init:function(){this.sourceView=this.views[0].cloneNode(!0),this.aptCont=this.views[0].parentElement},getStart:function(){return this.interval.start},getDuration:function(){return this.interval.duration},getEnd:function(){return w.dateIncreaseWithUtcOffset(this.getStart(),this.getDuration())},clearViews:function(){this.views.forEach((function(t){t.parentElement.removeChild(t)})),this.views=[]}},D.createItem=function(t,e,n,i){var o=function(t){return x(T.Attr.getStart(t[0]),T.Attr.getDuration(t[0]))}(e);return new D(t,e,o,o.duration>=w.DaySpan?n:i)},D.createItems=function(t,e,n){for(var i={},o=0,r=void 0;r=t[o];o++){var a=T.Attr.getAppointmentKey(r);i[a]||(i[a]=[]),i[a].push(r)}var l=[];for(var s in i)Object.prototype.hasOwnProperty.call(i,s)&&l.push(D.createItem(s,i[s],e,n));return l};var w={HalfHourSpan:18e5,DaySpan:864e5,dateSubsWithTimezone:function(t,e){return t-e+6e4*(e.getTimezoneOffset()-t.getTimezoneOffset())},truncToDate:function(t){return new Date(t.getFullYear(),t.getMonth(),t.getDate())},calculateDaysDifference:function(t,e){var n=w.truncToDate(t),i=w.truncToDate(e);return w.dateSubsWithTimezone(i,n)/w.DaySpan},dateIncreaseWithUtcOffset:function(t,e){var n=w.dateIncrease(t,e),i=6e4*(n.getTimezoneOffset()-t.getTimezoneOffset());return w.dateIncrease(n,i)},dateIncrease:function(t,e){return new Date(t.valueOf()+e)},addTimeSpan:function(t,e){return new Date(t.valueOf()+e)},toDayTime:function(t){return t.valueOf()-w.truncToDate(t).valueOf()}};function z(t,e){this.scheduler=t,this.dotnetHelper=e,this.interval=null,this.start=function(t){this.interval=H(t);var e=this.interval.start,n=w.dateIncreaseWithUtcOffset(e,this.interval.duration),i=6e4*e.getTimezoneOffset()*-1;this.dotnetHelper.invokeMethodAsync("OnCellSelectionStart",w.addTimeSpan(e,i),w.addTimeSpan(n,i),S(t))},this.resizeTo=function(t){var e=H(t),n=e.start-this.interval.start;if(0!==n||this.interval.duration!==e.duration){n<0&&this.interval.duration===e.duration?this.direction="top":n>0&&this.interval.duration===e.duration&&(this.direction="bottom"),"bottom"===this.direction?this.interval.duration=n+e.duration:"top"===this.direction&&(this.interval.start=e.start,this.interval.duration+=-1*n);var i=this.interval.start,o=w.dateIncreaseWithUtcOffset(i,this.interval.duration),r=6e4*i.getTimezoneOffset()*-1;this.dotnetHelper.invokeMethodAsync("OnCellSelectionResize",w.addTimeSpan(i,r),w.addTimeSpan(o,r),S(t))}},this.end=function(){this.dotnetHelper.invokeMethodAsync("OnCellSelectionEnd",this.scheduler.offsetWidth<500)}}function O(t,e){this.scheduler=t,this.dotnetHelper=e,this.appointmentInfo=null,this.interval=null,this.dragStart=function(t,e){this.appointmentInfo=t,this.sourceAppointmentInterval=x(t.getStart(),t.getDuration()),this.cellInterval=H(e),this.dateDiff=t.getStart()-this.cellInterval.start,this.dotnetHelper.invokeMethodAsync("OnAppointmentDragStart"),this.scheduler.skipCalculateAllAppointments=!0},this.drag=function(t){if(this.cellInterval){var e=H(t);if(this.cellInterval.start-e.start!=0||this.cellInterval.duration!==e.duration){e.isLongerOrEqualDay?this.sourceAppointmentInterval.isLongerOrEqualDay&&this.cellInterval.isLongerOrEqualDay===e.isLongerOrEqualDay?this.appointmentInfo.interval=x(w.addTimeSpan(e.start,this.dateDiff),this.appointmentInfo.interval.duration):(this.appointmentInfo.interval=e,this.appointmentInfo.allDay=!0):(this.appointmentInfo.interval.isLongerOrEqualDay&&(this.appointmentInfo.interval.duration=this.sourceAppointmentInterval.isLongerOrEqualDay?e.duration:this.sourceAppointmentInterval.duration),this.appointmentInfo.interval=x(w.addTimeSpan(e.start,this.dateDiff),this.appointmentInfo.interval.duration),this.appointmentInfo.allDay=!1);var n=6e4*e.start.getTimezoneOffset()*-1;this.dotnetHelper.invokeMethodAsync("OnAppointmentDrag",w.addTimeSpan(this.appointmentInfo.getStart(),n),w.addTimeSpan(this.appointmentInfo.getEnd(),n),this.appointmentInfo.allDay),this.cellInterval=e}}},this.resize=function(t,e,n){if(this.cellInterval){var i=H(t);if((this.cellInterval.start-i.start!=0||this.cellInterval.duration!==i.duration)&&this.cellInterval.isLongerOrEqualDay===i.isLongerOrEqualDay){var o=this.cellInterval.start-i.start;e?this.appointmentInfo.interval=x(w.addTimeSpan(i.start,this.dateDiff),this.appointmentInfo.interval.duration+o):this.appointmentInfo.interval.duration-=o;var r=6e4*i.start.getTimezoneOffset()*-1;this.dotnetHelper.invokeMethodAsync("OnAppointmentDrag",w.addTimeSpan(this.appointmentInfo.getStart(),r),w.addTimeSpan(this.appointmentInfo.getEnd(),r),this.appointmentInfo.allDay),this.cellInterval=i}}},this.dragEnd=function(){this.dotnetHelper.invokeMethodAsync("OnAppointmentDragEnd"),this.scheduler.skipCalculateAllAppointments=!1}}function L(t,e){for(var n={},i=0,o=void 0;o=t[i];i++){o.intersects=[];var r=T.Attr.getContainerIndex(o);n[r]||(n[r]=[]),n[r].push(o)}for(var a=0,l=void 0;l=e[a];a++){var s=T.Attr.getContainerIndex(l),c=T.Attr.getAppointmentFirstCellIndex(l),u=T.Attr.getAppointmentLastCellIndex(l);l.firstCell=n[s][c],l.lastCell=n[s][u]}}function M(t){t.style.height="",function(t,e){t.intersects.findIndex((function(t){return T.Attr.getAppointmentKey(t)===T.Attr.getAppointmentKey(e)}))<0&&t.intersects.push(e)}(t.firstCell,t),t.style.left=t.firstCell.offsetLeft+"px",t.style.width=t.lastCell===t.firstCell?t.firstCell.offsetWidth+"px":t.lastCell.offsetLeft-t.firstCell.offsetLeft+t.firstCell.offsetWidth+"px",t.firstCell.lastAppointmentTop||(t.firstCell.lastAppointmentTop=t.firstCell.offsetTop),t.style.display="",t.style.top=t.firstCell.lastAppointmentTop+"px",t.firstCell.lastAppointmentTop+=t.offsetHeight}function k(t){var e=T.Attr.getAppointmentColumn(t),n=t.firstCell.offsetWidth/T.Attr.getAppointmentColumnsCount(t);t.style.top=t.firstCell.offsetTop+"px",t.style.left=t.firstCell.offsetLeft+n*e+"px",t.style.width=n-10+"px",t.style.height=t.lastCell.offsetTop+t.lastCell.offsetHeight-t.firstCell.offsetTop+"px",t.style.display=""}function j(t,e,n,i){return function(t,e,n){var i=t.target;for(;i;){if(i===e)return!1;i=i.parentElement}n&&n()}(t,e,(function(){e&&"string"!=typeof e&&"none"!==e.style.display&&i.invokeMethodAsync(n)}))}function F(t,e){return new Date(t.valueOf()+e)}function N(t,e){return t-e+6e4*(e.getTimezoneOffset()-t.getTimezoneOffset())}function P(t){return(t=o.ensureElement(t))&&r.disposeEvents(t),Promise.resolve("ok")}n.default={init:A,dispose:P},n.dispose=P,n.init=A}),["cjs-chunk-c5286524.js","cjs-dom-utils-c4472fdd.js","cjs-chunk-fc814f01.js","cjs-chunk-2cdecb19.js","cjs-chunk-a0f3c48f.js"]);

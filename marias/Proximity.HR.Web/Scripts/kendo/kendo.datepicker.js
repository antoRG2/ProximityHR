/** 
 * Kendo UI v2016.3.1118 (http://www.telerik.com/kendo-ui)                                                                                                                                              
 * Copyright 2016 Telerik AD. All rights reserved.                                                                                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/
!function(e,define){define("kendo.datepicker.min",["kendo.calendar.min","kendo.popup.min"],e)}(function(){return function(e,t){function a(t){var a=t.parseFormats,n=t.format;F.normalize(t),a=e.isArray(a)?a:[a],a.length||a.push("yyyy-MM-dd"),e.inArray(n,a)===-1&&a.splice(0,0,t.format),t.parseFormats=a}function n(e){e.preventDefault()}var i,o=window.kendo,r=o.ui,l=r.Widget,s=o.parseDate,d=o.keys,u=o.template,c=o._activeElement,p="<div />",f="<span />",m=".kendoDatePicker",_="click"+m,v="open",h="close",g="change",w="disabled",k="readonly",y="k-state-default",b="k-state-focused",x="k-state-selected",D="k-state-disabled",A="k-state-hover",V="mouseenter"+m+" mouseleave"+m,C="mousedown"+m,T="id",O="min",I="max",R="month",E="aria-disabled",W="aria-expanded",N="aria-hidden",F=o.calendar,P=F.isInRange,H=F.restrictValue,S=F.isEqualDatePart,q=e.extend,z=e.proxy,K=Date,M=function(t){var a,n=this,i=document.body,l=e(p).attr(N,"true").addClass("k-calendar-container").appendTo(i);n.options=t=t||{},a=t.id,a&&(a+="_dateview",l.attr(T,a),n._dateViewID=a),n.popup=new r.Popup(l,q(t.popup,t,{name:"Popup",isRtl:o.support.isRtl(t.anchor)})),n.div=l,n.value(t.value)};M.prototype={_calendar:function(){var t,a=this,i=a.calendar,l=a.options;i||(t=e(p).attr(T,o.guid()).appendTo(a.popup.element).on(C,n).on(_,"td:has(.k-link)",z(a._click,a)),a.calendar=i=new r.Calendar(t),a._setOptions(l),o.calendar.makeUnselectable(i.element),i.navigate(a._value||a._current,l.start),a.value(a._value))},_setOptions:function(e){this.calendar.setOptions({focusOnNav:!1,change:e.change,culture:e.culture,dates:e.dates,depth:e.depth,footer:e.footer,format:e.format,max:e.max,min:e.min,month:e.month,start:e.start,disableDates:e.disableDates})},setOptions:function(e){var t=this.options,a=e.disableDates;a&&(e.disableDates=F.disabled(a)),this.options=q(t,e,{change:t.change,close:t.close,open:t.open}),this.calendar&&this._setOptions(this.options)},destroy:function(){this.popup.destroy()},open:function(){var e=this;e._calendar(),e.popup.open()},close:function(){this.popup.close()},min:function(e){this._option(O,e)},max:function(e){this._option(I,e)},toggle:function(){var e=this;e[e.popup.visible()?h:v]()},move:function(e){var t=this,a=e.keyCode,n=t.calendar,i=e.ctrlKey&&a==d.DOWN||a==d.ENTER,o=!1;if(e.altKey)a==d.DOWN?(t.open(),e.preventDefault(),o=!0):a==d.UP&&(t.close(),e.preventDefault(),o=!0);else if(t.popup.visible()){if(a==d.ESC||i&&n._cell.hasClass(x))return t.close(),e.preventDefault(),!0;t._current=n._move(e),o=!0}return o},current:function(e){this._current=e,this.calendar._focus(e)},value:function(e){var t=this,a=t.calendar,n=t.options,i=n.disableDates;i&&i(e)&&(e=null),t._value=e,t._current=new K((+H(e,n.min,n.max))),a&&a.value(e)},_click:function(e){e.currentTarget.className.indexOf(x)!==-1&&this.close()},_option:function(e,t){var a=this,n=a.calendar;a.options[e]=t,n&&n[e](t)}},M.normalize=a,o.DateView=M,i=l.extend({init:function(t,n){var i,r,d=this;l.fn.init.call(d,t,n),t=d.element,n=d.options,n.disableDates=o.calendar.disabled(n.disableDates),n.min=s(t.attr("min"))||s(n.min),n.max=s(t.attr("max"))||s(n.max),a(n),d._initialOptions=q({},n),d._wrapper(),d.dateView=new M(q({},n,{id:t.attr(T),anchor:d.wrapper,change:function(){d._change(this.value()),d.close()},close:function(e){d.trigger(h)?e.preventDefault():(t.attr(W,!1),r.attr(N,!0))},open:function(e){var a,n=d.options;d.trigger(v)?e.preventDefault():(d.element.val()!==d._oldText&&(a=s(t.val(),n.parseFormats,n.culture),d.dateView[a?"current":"value"](a)),t.attr(W,!0),r.attr(N,!1),d._updateARIA(a))}})),r=d.dateView.div,d._icon();try{t[0].setAttribute("type","text")}catch(u){t[0].type="text"}t.addClass("k-input").attr({role:"combobox","aria-expanded":!1,"aria-owns":d.dateView._dateViewID}),d._reset(),d._template(),i=t.is("[disabled]")||e(d.element).parents("fieldset").is(":disabled"),i?d.enable(!1):d.readonly(t.is("[readonly]")),d._old=d._update(n.value||d.element.val()),d._oldText=t.val(),o.notify(d)},events:[v,h,g],options:{name:"DatePicker",value:null,footer:"",format:"",culture:"",parseFormats:[],min:new Date(1900,0,1),max:new Date(2099,11,31),start:R,depth:R,animation:{},month:{},dates:[],ARIATemplate:'Current focused date is #=kendo.toString(data.current, "D")#'},setOptions:function(e){var t=this,n=t._value;l.fn.setOptions.call(t,e),e=t.options,e.min=s(e.min),e.max=s(e.max),a(e),t.dateView.setOptions(e),n&&(t.element.val(o.toString(n,e.format,e.culture)),t._updateARIA(n))},_editable:function(e){var t=this,a=t._dateIcon.off(m),i=t.element.off(m),o=t._inputWrapper.off(m),r=e.readonly,l=e.disable;r||l?(o.addClass(l?D:y).removeClass(l?y:D),i.attr(w,l).attr(k,r).attr(E,l)):(o.addClass(y).removeClass(D).on(V,t._toggleHover),i.removeAttr(w).removeAttr(k).attr(E,!1).on("keydown"+m,z(t._keydown,t)).on("focusout"+m,z(t._blur,t)).on("focus"+m,function(){t._inputWrapper.addClass(b)}),a.on(_,z(t._click,t)).on(C,n))},readonly:function(e){this._editable({readonly:e===t||e,disable:!1})},enable:function(e){this._editable({readonly:!1,disable:!(e=e===t||e)})},destroy:function(){var e=this;l.fn.destroy.call(e),e.dateView.destroy(),e.element.off(m),e._dateIcon.off(m),e._inputWrapper.off(m),e._form&&e._form.off("reset",e._resetHandler)},open:function(){this.dateView.open()},close:function(){this.dateView.close()},min:function(e){return this._option(O,e)},max:function(e){return this._option(I,e)},value:function(e){var a=this;return e===t?a._value:(a._old=a._update(e),null===a._old&&a.element.val(""),a._oldText=a.element.val(),t)},_toggleHover:function(t){e(t.currentTarget).toggleClass(A,"mouseenter"===t.type)},_blur:function(){var e=this,t=e.element.val();e.close(),t!==e._oldText&&e._change(t),e._inputWrapper.removeClass(b)},_click:function(){var e=this,t=e.element;e.dateView.toggle(),o.support.touch||t[0]===c()||t.focus()},_change:function(e){var t,a,n,i=this,r=i.element.val();e=i._update(e),t=!o.calendar.isEqualDate(i._old,e),a=t&&!i._typing,n=r!==i.element.val(),(a||n)&&i.element.trigger(g),t&&(i._old=e,i._oldText=i.element.val(),i.trigger(g)),i._typing=!1},_keydown:function(e){var t=this,a=t.dateView,n=t.element.val(),i=!1;a.popup.visible()||e.keyCode!=d.ENTER||n===t._oldText?(i=a.move(e),t._updateARIA(a._current),i||(t._typing=!0)):t._change(n)},_icon:function(){var t,a=this,n=a.element;t=n.next("span.k-select"),t[0]||(t=e('<span unselectable="on" class="k-select" aria-label="select"><span class="k-icon k-i-calendar"></span></span>').insertAfter(n)),a._dateIcon=t.attr({role:"button","aria-controls":a.dateView._dateViewID})},_option:function(e,a){var n=this,i=n.options;return a===t?i[e]:(a=s(a,i.parseFormats,i.culture),a&&(i[e]=new K((+a)),n.dateView[e](a)),t)},_update:function(e){var t,a=this,n=a.options,i=n.min,r=n.max,l=a._value,d=s(e,n.parseFormats,n.culture),u=null===d&&null===l||d instanceof Date&&l instanceof Date;return n.disableDates(d)&&(d=null,a._old||a.element.val()||(e=null)),+d===+l&&u?(t=o.toString(d,n.format,n.culture),t!==e&&a.element.val(null===d?e:t),d):(null!==d&&S(d,i)?d=H(d,i,r):P(d,i,r)||(d=null),a._value=d,a.dateView.value(d),a.element.val(o.toString(d||e,n.format,n.culture)),a._updateARIA(d),d)},_wrapper:function(){var t,a=this,n=a.element;t=n.parents(".k-datepicker"),t[0]||(t=n.wrap(f).parent().addClass("k-picker-wrap k-state-default"),t=t.wrap(f).parent()),t[0].style.cssText=n[0].style.cssText,n.css({width:"100%",height:n[0].style.height}),a.wrapper=t.addClass("k-widget k-datepicker k-header").addClass(n[0].className),a._inputWrapper=e(t[0].firstChild)},_reset:function(){var t=this,a=t.element,n=a.attr("form"),i=n?e("#"+n):a.closest("form");i[0]&&(t._resetHandler=function(){t.value(a[0].defaultValue),t.max(t._initialOptions.max),t.min(t._initialOptions.min)},t._form=i.on("reset",t._resetHandler))},_template:function(){this._ariaTemplate=u(this.options.ARIATemplate)},_updateARIA:function(e){var t,a=this,n=a.dateView.calendar;a.element.removeAttr("aria-activedescendant"),n&&(t=n._cell,t.attr("aria-label",a._ariaTemplate({current:e||n.current()})),a.element.attr("aria-activedescendant",t.attr("id")))}}),r.plugin(i)}(window.kendo.jQuery),window.kendo},"function"==typeof define&&define.amd?define:function(e,t,a){(a||t)()});
//# sourceMappingURL=kendo.datepicker.min.js.map

DxBlazorInternal.define("cjs-popup-a4914a2c.js",(function(e,t,d){function n(e,t,d){t!==d&&!function(e,t){var d=0;t?(e.style.paddingRight=o(e)+i()+"px",d=parseFloat(o(document.body))+i(),document.body.classList.add("modal-open")):(document.body.classList.remove("modal-open"),d=parseFloat(o(document.body))-i(),e.style.paddingRight=o(e)-i()+"px");document.body.style.paddingRight=d+"px"}(e,t),e.style.visibility=t?"visible":"hidden"}function o(e){return parseFloat(window.getComputedStyle(e,null).getPropertyValue("padding-right"))}function i(){return window.innerWidth-document.body.getBoundingClientRect().width}d.default={renderModal:n},d.renderModal=n}),[]);

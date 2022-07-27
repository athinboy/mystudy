'use strict';

window.cascader = {

    //默认配置
    defaultOption: {
        placeHold: '选吧，你倒是选呀！',
        multiSelect: false,
        targeDom: null,
        cssclassprefix: 'jquery_',
        data: []
    },
    htmlTemplate: {
        'tagsContainer': '<div class="${cssclassprefix}cascader__tags"></div>',
        'cascaderInstance': '<div class="${cssclassprefix}cascader"></div>',
        'cascaderInput': '<div class="${cssclassprefix}cascader_input"> <input type="text" readonly="readonly" autocomplete="off" placeholder="${placeHold}"'
            + '  class="${cssclassprefix}cascader_input_inputter" aria-expanded="true" />        <span class="${cssclassprefix}cascader-input-suffix">  '
            + '          <span class="cascader-input-suffix-inner">                <i class="${cssclassprefix}cascader-input__icon ${cssclassprefix}cascader-icon-arrow-down"></i> '
            + '          </span>        </span>    </div>',
        'cascaderPanelContainer': '<div class="${cssclassprefix}cascader_panel_container"></div>',
        'cascaderPanel': '<div class="${cssclassprefix}cascader_panel"></div>',

    },

    createDOM: function (templateid, para) {

        let _htmltemplate = window.cascader.htmlTemplate[templateid];
        this.etpl = etpl.compile(_htmltemplate);
        let _htmlstr = this.etpl(para);
        let _dom = $(_htmlstr);
        return _dom;
    },
    build: function (_domId, _option) {
        if (!_domId) {
            this.showError('dom id 为空！');
            return;
        }
        _domId = '#' + _domId;

        let _targeDom = $(_domId);
        if (_targeDom.length == 0) {
            this.showError(_domId + '不存在！');
            return;
        }
        _option = $.extend(_option || {}, this.defaultOption);
        _option.targeDom = _targeDom;

        function inputContainer(_option) {
            this.option = _option;
            this.dom = null;
        }
        inputContainer.prototype = {
            render: function (_cascaderDom) {
                let _dom = window.cascader.createDOM('cascaderInput', this.option);
                this.dom = _dom;
                _cascaderDom.append(_dom);

            }

        };
        function candidateItemMenuItem() {

        }
        candidateItemMenuItem.prototype = {
            constructor: this.candidateItemMenuItem
        };
        function candidateItemMenu() {

        }

        candidateItemMenu.prototype = {
            constructor: this.candidateItemMenu,
            render: function () {

            }
        };
        function candidateItemPanel(_option) {
            this.option = _option;
            this.containerDom = null;
            this.panelDom = null;
            this.itemMenus=[];

        }
        candidateItemPanel.prototype = {
            constructor: this.candidateItemPanel,
            render: function () {
                let _dom = window.cascader.createDOM('cascaderPanelContainer', this.option);
                this.containerDom = _dom;
                _dom = window.cascader.createDOM('cascaderPanel', this.option);
                this.panelDom = _dom;
                this.containerDom.append(this.panelDom);
                $('body').append(this.containerDom);
                
            }

        };
        function cascaderInstance(_option) {
            this.option = _option;
            this.inputContainer = new inputContainer(_option);
            this.candidatePanel = new candidateItemPanel(_option);
            this.etpl = null;
            this.dom = null;
        }

        cascaderInstance.prototype = {
            constructor: this.cascaderInstance,
            option: null,
            render: function () {

                let _dom = window.cascader.createDOM('cascaderInstance', this.option);
                this.dom = _dom;
                this.option.targeDom.hide();
                this.option.targeDom.after(_dom);
                this.inputContainer.render(this.dom);
                this.candidatePanel.render();

            }

        };


        let instance = new cascaderInstance(_option);
        instance.render();



    },
    showError(msg) {
        if (console && console.error) {
            console.error(msg);
        }
    },





};

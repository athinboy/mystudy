'use strict';

window.cascader = {
    //默认配置
    defaultOption: {
        debugging: false,
        placeHold: '选吧，你倒是选呀！',
        multiSelect: false,
        targeDom: null,
        cssclassprefix: 'jquery_',
        data: []
    },
    htmlTemplate: {
        'tagsContainer': '<div class="${option.cssclassprefix}cascader__tags"></div>',
        'cascaderInstance': '<div class="${option.cssclassprefix}cascader"></div>',
        'cascaderInput': '<div class="${option.cssclassprefix}cascader_input"> <input type="text" readonly="readonly" autocomplete="off" placeholder="${option.placeHold}"'
            + '  class="${option.cssclassprefix}cascader_input_inputter" aria-expanded="true" />        <span class="${option.cssclassprefix}cascader-input-suffix">  '
            + '          <span class="cascader-input-suffix-inner">                <i class="${option.cssclassprefix}cascader-input__icon ${option.cssclassprefix}cascader-icon-arrow-down"></i> '
            + '          </span>        </span>    </div>',
        'cascaderPanelContainer': '<div class="${option.cssclassprefix}cascader_panel_container"></div>',
        'cascaderPanel': '<div class="${option.cssclassprefix}cascader_panel"></div>',
        'menuItem': '<li role="menuitem" class="${option.cssclassprefix}cascader_menu_node is-disabled" >     ' +
            '    <span class="${option.cssclassprefix}cascader_menu_node_label">${data.text}</span><i     ' +
            '            class="${option.cssclassprefix}cascader-input__icon ${option.cssclassprefix}cascader-icon-arrow-right ${option.cssclassprefix}cascader-node-postfix"></i>     ' +
            '    </li>   '

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

        let _tempoption = this.defaultOption;
        $.extend(_tempoption, _option || {});
        _option = _tempoption;
        _option.targeDom = _targeDom;
        _option.data = _option.data || [];

        if (_option.debugging && window.console && window.console.debug) {
            window.console.debug(_option);
        }

        function inputContainer(_option) {
            this.option = _option;
            this.dom = null;
        }
        inputContainer.prototype = {
            render: function (_cascaderDom) {
                let _dom = window.cascader.createDOM('cascaderInput', { "option": this.option });
                this.dom = _dom;


                if (this.option.debugging && window.console && window.console.debug) {
                    window.console.debug(_dom.find('.' + this.option.cssclassprefix + 'cascader-input-suffix').length);
                }

                _cascaderDom.append(_dom);
                _dom.find('.' + this.option.cssclassprefix + 'cascader-input-suffix').on('click', function () {

                    window.console.debug(111111111);
                });


            }

        };
        function candidateItemMenuItem(_containerdom, _data, _option) {
            this.data = _data;
            this.option = _option;
            this.containerDom = _containerdom;
            this.dom = null;
        }
        candidateItemMenuItem.prototype = {
            constructor: this.candidateItemMenuItem,
            render: function () {
                let _dom = window.cascader.createDOM('menuItem', { "data": this.data, "option": this.option });
                this.dom = _dom;
                this.containerDom.append(_dom);
            }

        };
        function candidateItemMenu(_data, _option) {
            this.data = _data;
            this.option = _option;
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
            this.itemMenus = [];

        }
        candidateItemPanel.prototype = {
            constructor: this.candidateItemPanel,
            render: function (_inputContainer) {
                let _dom = window.cascader.createDOM('cascaderPanelContainer', { "option": this.option });
                this.containerDom = _dom;
                _dom = window.cascader.createDOM('cascaderPanel', { "option": this.option });
                this.panelDom = _dom;
                this.containerDom.append(this.panelDom);
                $('body').append(this.containerDom);
                if (window.console && window.console.info) {
                    window.console.info(_inputContainer.dom.offset());
                }
                this.containerDom.css("left", _inputContainer.dom.offset().left + 'px');
                this.containerDom.css("top", (_inputContainer.dom.offset().top + _inputContainer.dom.height) + 'px');

            },
            addMenu: function (_data, _option) {
                let newMenu = new candidateItemMenu(_data, _option);
                newMenu.render();
                this.itemMenus.push(newMenu);
            },
            show:function(){
                $(this.containerDom).show();
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

                let _dom = window.cascader.createDOM('cascaderInstance', { "option": this.option });
                _dom.on('click', function () {
                    let instance= this.cascader;
                    instance.showCandidate();                    
                    debugger;
                });
                this.dom = _dom;     
                this.dom[0].cascader=this;
                debugger;        
                this.option.targeDom.hide();
                this.option.targeDom.after(_dom);
                this.inputContainer.render(this.dom);
                this.candidatePanel.render(this.inputContainer);
                if (this.option.data && this.option.data.length > 0) {
                    $.each(function (index, value) {
                        this.candidatePanel.addMenu(value);
                    });

                }

            },
            showCandidate:function(){
this.candidatePanel.show();
            }


        };


        let instance = new cascaderInstance(_option);
        instance.render();



    },
    showError(msg) {
        if (console && console.error) {
            console.error(msg);
        }
    }





};

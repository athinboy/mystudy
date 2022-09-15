/* jshint esversion: 6 */

//'use strict';
(

    function () {
        'use strict';
        window.cascader = {
            //默认配置
            defaultOption: {
                debugging: false,//调试模式
                placeHold: '选吧，你倒是选呀！',//输入框占位符
                multiSelect: false,//多选
                targeDom: null,//替代的目标html dom
                cssclassprefix: 'jquery_',//css类前缀
                hoverExpand: false,//鼠标hover时展开子菜单
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
                'menu': '<div class="${option.cssclassprefix}cascader_menu"></div>',
                'menu_wrap': '<div class="${option.cssclassprefix}cascader_menu_wrap"></div>',
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

                //输入控件
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

                //选项项目
                function candidateItemMenuItem(_menu, _data, _option) {
                    //debugger;
                    console.assert(_menu != null, '_menu ==null');
                    console.assert(_data != null, '_data ==null');
                    console.assert(_option != null, '_option ==null');
                    this.data = _data;
                    this.option = _option;
                    this.itemMenu = _menu;
                    this.itemDom = null;
                    this.subMenu = null;
                    this.itemIndex = 1;
                }
                candidateItemMenuItem.prototype = {
                    constructor: this.candidateItemMenuItem,
                    //显示子菜单
                    showChildMenu: function () {
                        debugger;
                        let _itemData = this.data;
                        if (this.subMenu == null && _itemData.subData != null && _itemData.subData.length > 0) {

                            let newMenu = new candidateItemMenu(this.itemMenu.menuPanelDom, _itemData.subData, this.option, this);
                            this.subMenu = newMenu;

                        }
                        if (this.subMenu != null) {
                            this.subMenu.render();
                        }


                    },
                    render: function () {

                        let _dom = window.cascader.createDOM('menuItem', { "data": this.data, "option": this.option });
                        this.itemDom = _dom;
                        this.itemDom[0].cascaderMenuItem = this;
                        _dom.mouseleave(function () {
                            window.console.debug('mouse leave');
                        });
                        _dom.mouseenter(function () {
                            window.console.debug('mouse enter');
                            let _cascaderMenuItem = this.cascaderMenuItem;
                            if (_cascaderMenuItem.option.hoverExpand) {
                                _cascaderMenuItem.showChildMenu();
                            }


                        });
                        _dom.click(function () {
                            let _cascaderMenuItem = this.cascaderMenuItem;
                            _cascaderMenuItem.showChildMenu();

                        });
                        //debugger;
                        this.itemMenu.menuDom.append(_dom);
                    }

                };

                //选项菜单列表
                function candidateItemMenu(_menuPanelDom, _data, _option, _parentMenu) {
                    console.assert(_menuPanelDom != null, '_menuPanelDom ==null');
                    console.assert(_data != null, '_data ==null');
                    console.assert(_option != null, '_option ==null');
                    this.data = _data;
                    this.option = _option;
                    this.muneItems = [];
                    this.menuDom = null;
                    this.menuPanelDom = _menuPanelDom;
                    this.itemIndex = 1;
                    this.parentMenu = _parentMenu;
                }
                candidateItemMenu.prototype = {
                    constructor: this.candidateItemMenu,
                    render: function () {
                        let _dom = window.cascader.createDOM('menu', { "option": this.option });
                        this.menuDom = _dom;
                        this.menuDom.cascaderMenu = this;
                        this.menuPanelDom.append(_dom);
                        let _muneItems = this.muneItems;
                        let _menuDom = this.menuDom;
                        let _option = this.option;
                        let _itemMenu = this;
                        $.each(this.data, function (_index, _value) {

                            let _newitem = new candidateItemMenuItem(_itemMenu, _value, _option);
                            _muneItems.push(_newitem);
                            _newitem.render();
                        });


                    }
                };

                //选项面板
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
                        this.panelDom[0].cascaderPanel = this;
                        console.info(this.containerDom);
                        this.containerDom.append(this.panelDom);
                        $('body').append(this.containerDom);
                        if (window.console && window.console.info) {
                            window.console.info(_inputContainer.dom.offset());
                        }

                        this.containerDom.css("left", _inputContainer.dom.offset().left + 'px');
                        this.containerDom.css("top", (_inputContainer.dom.offset().top + _inputContainer.dom.height) + 'px');

                    },
                    addMenu: function (_data, _option) {
                        //debugger;
                        let newMenu = new candidateItemMenu(this.panelDom, _data, _option);
                        newMenu.render();
                        this.itemMenus.push(newMenu);


                    },
                    show: function () {
                        $(this.containerDom).show();
                    }

                };

                //cascader实例
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

                            let instance = this.cascader;
                            instance.showCandidate();

                        });

                        this.dom = _dom;
                        this.dom[0].cascader = this;

                        this.option.targeDom.hide();
                        this.option.targeDom.after(_dom);
                        this.inputContainer.render(this.dom);
                        this.candidatePanel.render(this.inputContainer);

                        if (this.option.data && this.option.data.length > 0) {
                            this.candidatePanel.addMenu(this.option.data, this.option);
                        }

                    },
                    showCandidate: function () {
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
    }

)();


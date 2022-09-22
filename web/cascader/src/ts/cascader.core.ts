// import $ from 'jquery' 
declare var etpl: any;
declare var $: any;
declare var window: any;

export class CascaderOption {

    targetDomId: string;
    debugging: boolean = false;//调试模式
    placeHold: string = '选吧，你倒是选呀！';//输入框占位符
    multiSelect: boolean = false;//多选
    targeDom: any = null;//替代的目标html dom
    cssclassprefix: string = 'jquery_';//css类前缀（非公开）。//todo 移除此字段
    hoverExpand: boolean = false;//鼠标hover时展开子菜单
    onlyLeaf: true;//仅叶节点可选
    domIdPrefix: string = 'jqcascader_';//dom id前缀。
    data: Array<object> = null;
    copy(extendvalue: any) {
        extendvalue = extendvalue ?? {};
        return $.extend($.extend(true, {}, this), extendvalue)
    }
    validate() {

        //todo 校验data、targeDom、targetDomId

    }


}


export enum CascaderHtmlTemplate {
    'tagsContainer' = '<div id="${option.domid}" class="jqcascader__tags"></div>',
    'CascaderInstance' = '<div id="${option.domid}" class="jqcascader_cascader"></div>',
    'cascaderInput' = '<div id="${option.domid}" class="jqcascader_input"> <input type="text" readonly="readonly" autocomplete="off" placeholder="${option.placeHold}"'
    + '  class="jqcascader_input_inputter" aria-expanded="true" />        <span class="jqcascader_cascader-input-suffix">  '
    + '          <span class="cascader-input-suffix-inner">                <i class="jqcascader_cascader-input__icon jqcascader_cascader-icon-arrow-down"></i> '
    + '          </span>        </span>    </div>',
    'cascaderPanelContainer' = '<div id="${option.domid}" class="jqcascader_panel_container">  <div x-arrow="" class="popper__arrow jqcascader_popper_arrow" style="left: 35px;"></div> </div>',
    'cascaderPanel' = '<div id="${option.domid}" class="jqcascader_panel"></div>',
    'menu' = '<div id="${option.domid}" class="jqcascader_menu"></div>',
    'menu_wrap' = '<div id="${option.domid}" class="jqcascader_menu_wrap"></div>',
    'menuItem' = '<li id="${option.domid}" role="menuitem" class="jqcascader_menu_node is-disabled" >     ' +
    '    <span class="jqcascader_menu_node_label">${data.text}</span> ' +
    '    </li>   ',
    'rightArrow' = '<i class="el-icon-arrow-right jqcascader-icon-arrow-right jqcascader-node-postfix  el-cascader-node__postfix "></i>',
    'checkBox' = '<label class="el-checkbox"><span class="el-checkbox__input"><span class="el-checkbox__inner"></span><input type="checkbox" aria-hidden="false" class="el-checkbox__original" value=""></span></label>',
    'selectedTagContainer'=''

}

export class CascaderCore {


    etpl: any;//etpl对象，https://github.com/ecomfe/etpl 
    instances: Array<CascaderInstance> = [];//页面实例

    constructor() {

        $('body').bind('mousedown', function (event) {
            //https://developer.mozilla.org/en-US/docs/Web/API/Element/mousedown_event
            //window.console.info(event);
            let core: CascaderCore = window.cascaderCore;
            core.instances.forEach(ci => { ci.dealMouseDown() });
        });
    }

    createDOM(templateid: string, para: object) {

        let _htmltemplate = CascaderHtmlTemplate[templateid];
        this.etpl = etpl.compile(_htmltemplate);
        let _htmlstr = this.etpl(para);
        let _dom = $(_htmlstr);
        return _dom;
    }

    build(_domId: string, _option: CascaderOption) {
        if (!_domId) {
            this.showError('dom id 为空！');
            return;
        }

        let _targeDom = $('#' + _domId);
        if (_targeDom.length == 0) {
            this.showError(_domId + '不存在！');
            return;
        }

        let _tempoption = new CascaderOption();

        $.extend(_tempoption, _option || {});
        _option = _tempoption;
        _option.validate();
        _option.targeDom = _targeDom;
        _option.data = _option.data || [];
        _option.targetDomId = _domId;

        if (_option.debugging && window.console && window.console.debug) {
            window.console.debug(_option);
        }



        let instance = new CascaderInstance(this, _option);
        instance.render();



    }

    showError(msg) {
        if (console && console.error) {
            console.error(msg);
        }
    }
}
class SeledTag {
    tagDom:any=null;    
    menuItem:CascaderMenuItem=null;//对应的菜单项目

    constructor(_menuitem:CascaderMenuItem) {

    }


}

//输入控件
class CascaderInputContainer {

    option: CascaderOption = null;
    dom: any = null;
    cascadercore: CascaderCore = null;
    cascaderInstance: CascaderInstance;
    domId: string = '';

    constructor(_cascaderInstance: CascaderInstance, _option: CascaderOption) {
        this.option = _option;
        this.dom = null;
        this.cascadercore = _cascaderInstance.cascadercore;
        this.cascaderInstance = _cascaderInstance;
        this.domId = this.cascaderInstance.domIdPrefix + 'input';
    }
    render(_cascaderDom) {
        let _dom = this.cascadercore.createDOM('cascaderInput', { "option": this.option.copy({ "domid": this.domId }) });
        this.dom = _dom;


        if (this.option.debugging && window.console && window.console.debug) {
            window.console.debug(_dom.find('.' + this.option.cssclassprefix + 'cascader-input-suffix').length);
        }

        _cascaderDom.append(_dom);
        _dom.find('.' + this.option.cssclassprefix + 'cascader-input-suffix').on('click', function () {

            window.console.debug(111111111);
        });


    }
}

//选项项目
class CascaderMenuItem {
    hideChildMenu() {
        if (this.subMenu) {
            this.subMenu.hideSubMenu();
            this.subMenu.hide();
        }
    }

    cascadercore: CascaderCore
    data: any;
    option: CascaderOption;
    itemMenu: CascaderMenu;//所属菜单
    itemDom: any = null;
    subMenu: CascaderMenu = null;//对应子菜单
    domid: string = '';
    arrowDom: any = null;//指向右的箭头图标Dom
    checkBoxDom: any = null;//复选框Dom
    seleted: boolean = false;//是否选中

    constructor(_menu: CascaderMenu, _data: any, _option: CascaderOption) {
        //debugger;
        console.assert(_menu != null, '_menu ==null');
        console.assert(_data != null, '_data ==null');
        console.assert(_option != null, '_option ==null');

        this.data = _data;
        this.option = _option;
        this.itemMenu = _menu;
        this.itemDom = null;
        this.subMenu = null;

        this.cascadercore = _menu.cascadercore;
        if (this.itemMenu.parentMenuItem) {
            this.domid = this.itemMenu.parentMenuItem.domid + '_' + this.itemMenu.nextIndex();
        } else {
            this.domid = this.itemMenu.cascaderInstance.domIdPrefix + '' + this.itemMenu.nextIndex();
        }

    }
    isLeaf() {
        let _itemData = this.data;

        if (_itemData.subData != null && _itemData.subData.length > 0) {
            return false
        } else {
            return true;
        }
    }
    //添加右向箭头
    addRightArrow() {
        let _rightDom = this.cascadercore.createDOM('rightArrow', {});
        this.itemDom.append(_rightDom);

    }
    //显示子菜单
    showChildMenu() {

        this.itemMenu.hideSubMenu();
        if (this.subMenu != null) {
            this.subMenu.show();
            return;
        }

        let _itemData = this.data;

        if (this.subMenu == null && _itemData.subData != null && _itemData.subData.length > 0) {

            let newMenu = new CascaderMenu(this.itemMenu.menuPanel, _itemData.subData, this.option, this);
            this.subMenu = newMenu;
            this.subMenu.render();

        }



    }
    render() {

        let _dom = this.cascadercore.createDOM('menuItem', { "data": this.data, "option": this.option.copy({ "domid": this.domid }) });
        this.itemDom = _dom;
        this.itemDom[0].cascaderMenuItem = this;
        if (this.option.multiSelect) {

            let _checkboxdom = this.cascadercore.createDOM('checkBox', {});
            _checkboxdom.menuItem = this;
            this.itemDom.prepend(_checkboxdom);
            //todo 处理复选框的选取/取消事件

        }

        if (this.data.subData != null && this.data.subData.length > 0) {
            //todo 添加右向箭头图标
            this.addRightArrow();
        }


        _dom.mouseleave(function () {
            window.console.debug('mouse leave');
        });
        _dom.mouseenter(function () {
            let _cascaderMenuItem: CascaderMenuItem = this.cascaderMenuItem;
            if (_cascaderMenuItem.option.hoverExpand) {
                _cascaderMenuItem.showChildMenu();
            }

        });
        _dom.click(function () {
            let _cascaderMenuItem: CascaderMenuItem = this.cascaderMenuItem;
            //debugger;
            if (_cascaderMenuItem.isLeaf()) {
                _cascaderMenuItem.doChangeSelect();
            } else {
                _cascaderMenuItem.showChildMenu();
            }


        });
        //debugger;
        this.itemMenu.menuDom.append(_dom);
    }
    //处理--选择变化
    doChangeSelect() {
        if (this.seleted) {
            this.seleted = false;
            this.itemMenu.cascaderInstance.removeSelectedMenuItem(this);
            this.itemDom.removeClass('is-checked');
        } else {
            this.seleted = true;
            this.itemMenu.cascaderInstance.addSelectedMenuItem(this);
            this.itemDom.addClass('is-checked');
        }

    }

};


//选项菜单列表
class CascaderMenu {
    show() {
        if (this.menuDom) {
            this.menuDom.show();
        }
    }
    hide() {
        if (this.menuDom) {
            this.menuDom.hide();
        }
    }
    hideSubMenu() {
        for (let index = 0; index < this.menuItems.length; index++) {
            const element = this.menuItems[index];
            element.hideChildMenu();
        }
    }

    data: any;
    option: CascaderOption;
    menuItems: Array<CascaderMenuItem> = [];
    menuDom: any;
    menuPanelDom: any;
    itemIndex: number;
    parentMenuItem: CascaderMenuItem;//对应的父菜单中的项目
    cascadercore: CascaderCore;
    cascaderInstance: CascaderInstance;
    menuPanel: CascaderMenuPanel;
    domid: string = '';

    nextIndex() {
        return this.itemIndex++;
    }

    constructor(_menuPanel: CascaderMenuPanel, _data, _option: CascaderOption, _parentMenuItem: CascaderMenuItem) {

        console.assert(_data != null, '_data ==null');
        console.assert(_option != null, '_option ==null');
        console.assert(_menuPanel != null, '_menuPanel ==null');

        this.data = _data;
        this.option = _option;
        this.menuItems = [];
        this.menuDom = null;
        this.menuPanelDom = _menuPanel.panelDom;
        this.itemIndex = 1;
        this.parentMenuItem = _parentMenuItem;
        this.cascadercore = _menuPanel.cascadercore;
        this.menuPanel = _menuPanel;
        this.cascaderInstance = _menuPanel.cascaderInstance;

        if (_parentMenuItem) {
            this.domid = _parentMenuItem.domid + '-menu';
        } else {
            this.domid = this.cascaderInstance.domIdPrefix + '-menu';
        }
    }

    render() {
        if (this.menuDom == null) {
            let _dom = this.cascadercore.createDOM('menu', { "option": this.option.copy({ "domid": this.domid }) });
            this.menuDom = _dom;
            this.menuDom.cascaderMenu = this;
            this.menuPanelDom.append(_dom);
            let _muneItems = this.menuItems;
            let _menuDom = this.menuDom;
            let _option = this.option;
            let _itemMenu = this;
            let _cascadercore = this.cascadercore;
            $.each(this.data, function (_index, _value) {

                let _newitem = new CascaderMenuItem(_itemMenu, _value, _option);
                _muneItems.push(_newitem);
                _newitem.render();
            });
        } else {

        }



    }
};


//选项面板
class CascaderMenuPanel {
    cascadercore: CascaderCore;
    option: CascaderOption;
    containerDom: any;
    panelDom: any;
    itemMenus: Array<CascaderMenu> = [];
    cascaderInstance: CascaderInstance;
    mouseLeave: boolean = false;
    mouseEnter: boolean = false;
    constructor(_cascaderInstance: CascaderInstance, _option: CascaderOption) {
        this.option = _option;
        this.containerDom = null;
        this.panelDom = null;
        this.itemMenus = [];
        this.cascadercore = _cascaderInstance.cascadercore;
        this.cascaderInstance = _cascaderInstance;

    }

    render(_inputContainer) {

        const _containerSuffix: string = this.cascaderInstance.domIdPrefix + 'menupanelcontainer';
        const _panelSuffix: string = this.cascaderInstance.domIdPrefix + 'menupanel';
        let _dom = this.cascadercore.createDOM('cascaderPanelContainer', { "option": this.option.copy({ "domid": _containerSuffix }) });
        this.containerDom = _dom;
        _dom = this.cascadercore.createDOM('cascaderPanel', { "option": this.option.copy({ "domid": _panelSuffix }) });
        this.panelDom = _dom;
        _dom.cascaderMenuPanel = this;
        this.panelDom[0].cascaderPanel = this;
        console.info(this.containerDom);
        this.containerDom.append(this.panelDom);
        $('body').append(this.containerDom);

        _dom.mouseleave(function () {
            let _menuPanel: CascaderMenuPanel = _dom.cascaderMenuPanel;
            _menuPanel.mouseLeave = true;
            _menuPanel.mouseEnter = false;
        });
        _dom.mouseenter(function () {
            let _menuPanel: CascaderMenuPanel = _dom.cascaderMenuPanel;
            _menuPanel.mouseLeave = false;
            _menuPanel.mouseEnter = true;
        });


    }
    addMenu(_data, _option) {
        //debugger;
        let newMenu = new CascaderMenu(this, _data, _option, null);
        newMenu.render();
        this.itemMenus.push(newMenu);
    }
    show() {
        let inputoffset = this.cascaderInstance.inputContainer.dom.offset();
        let inputheight = this.cascaderInstance.inputContainer.dom.outerHeight();
        this.containerDom.css("position", 'absolute');
        this.containerDom.css("left", inputoffset.left + 'px');
        this.containerDom.css("top", (inputoffset.top + inputheight) + 'px');

        $(this.containerDom).show();
    }
    hide() {
        $(this.containerDom).hide();
    }

};

//cascader实例
export class CascaderInstance {

    option: CascaderOption;
    inputContainer: CascaderInputContainer;
    candidatePanel: CascaderMenuPanel;
    etpl: any;
    dom: any;
    cascadercore: CascaderCore
    domIdPrefix: string = '';
    selectedMenuItems: Array<CascaderMenuItem> = [];//选择的菜单项目
    values: Array<string> = [];//值

    constructor(_cascadercore: CascaderCore, _option: CascaderOption) {
        this.cascadercore = _cascadercore;
        this.option = _option;
        this.etpl = null;
        this.dom = null;
        this.domIdPrefix = _option.domIdPrefix + _option.targetDomId + '_';

        this.inputContainer = new CascaderInputContainer(this, _option);
        this.candidatePanel = new CascaderMenuPanel(this, _option);

    }

    addSelectedMenuItem(_item: CascaderMenuItem) {
        if (null == this.selectedMenuItems.find(smi => smi.domid == _item.domid)) {
            this.selectedMenuItems.push(_item);
            this.values = this.selectedMenuItems.map(x => x.data.id);
        }

    }

    removeSelectedMenuItem(_item: CascaderMenuItem) {

        this.selectedMenuItems = this.selectedMenuItems.filter(smi => smi.domid != _item.domid);
        this.values = this.selectedMenuItems.map(x => x.data.id);

    }

    render() {

        let _dom = this.cascadercore.createDOM('CascaderInstance', { "option": this.option });
        _dom.on('click', function () {

            let instance: CascaderInstance = this.cascader;
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

        this.cascadercore.instances.push(this);


    }
    showCandidate() {
        this.candidatePanel.show();
    }
    dealMouseDown() {
        if (this.candidatePanel.mouseLeave) {
            this.candidatePanel.hide();
        }

    }


};




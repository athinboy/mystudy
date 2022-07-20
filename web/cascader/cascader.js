'use strict';




window.cascader = {

    //默认配置
    defaultOption: {
        placeHold: '选吧，你倒是选呀！',
        multiSelect: false
    },
    build: function (domId, option) {
        if (!domId) {
            this.showError('dom id 为空！');
            return;
        }
        option = option || {};
        let targeDom = $(domId);
        if (targeDom.length == 0) {
            this.showError(domId + '不存在！');
            return;
        }
        targeDom.hide();

        targeDom.append();




    },
    showError(msg) {
        if (console && console.error) {
            console.error(msg);
        }
    },
    



};

/* jshint esversion: 6 */

const { CascaderCore } = require("./cascader.core");

//'use strict';
(

    function () {
        'use strict';
        window.cascader = {
            cascaderCore:null,

            build: function (_domId, _option) {
                if(this.cascaderCore==null){
                    this.cascaderCore=new CascaderCore();
                }
                window.cascaderCore=this.cascaderCore;
                this.cascaderCore.build(_domId,_option);
            }

        };
    }

)();


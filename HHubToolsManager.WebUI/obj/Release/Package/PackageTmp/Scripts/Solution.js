

function createIframe(obj, url) {
    var o = obj || document.getElementById('iframetarget');
    var iframe = document.createElement('iframe');
    iframe.src = url;
    //iframe.scrolling = "no";
    iframe.frameBorder = 0;
    iframe.width = '100%';
    iframe.height = '100%';
    iframe.onload = function (e) {
        var $o = $(e.target);
        $o.height(window.outerHeight - 250);
        $('.loading-box').hide();
    }
    o.appendChild(iframe);
}

//
// aplay jQuery
function loadPageMain(obj, url) {
    var h = location.origin;
    obj.load(h + '/' + url, function () {
        $('.loading-box').hide();
    });
}

function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.Gid;
    });
}
function addSuccess(d, s, o) {
    if (s !== "success") {
        $('.result-error-message').show().text("很抱歉，请求遇到了错误。");
    }
    if (typeof d == "object") {
        if (d.Status === 0) {
            $(".modal .close").trigger('click');
            RefreshTable();
            $('.result-error-message').hide();
        } else {
            $('.result-error-message').show().text(d.Message);
        }
    } else {
        $('.result-error-message').hide();
        $(".modal .close").trigger('click');
        RefreshTable();
    }

};
function UpdatePasswordSuccess(d, s, o) {
    if (s !== "success") {
        $('#result-error-message').show().text("很抱歉，请求遇到了错误。");
    }
    if (typeof d == "object") {
        if (d.Status === 0) {
            $(".modal .close").trigger('click');
            RefreshTable();
            $('#result-error-message').hide();
        } else {
            $('#result-error-message').show().text(d.Message);
        }
    } else {
        $('#result-error-message').hide();
        $(".modal .close").trigger('click');
        RefreshTable();
    }

};
function RefreshTable() {
    $('.bootstrap-table button[title="Refresh"]').trigger('click');
}

function CreateEasyXDMIframe(obj, url) {
    if (typeof easyXDM === "undefined" || typeof echoToken === "undefined") {
        return;
    }
    var xhr = new easyXDM.Socket(/** The configuration */{
        remote: url,
        swf: "~/easyxdm.swf",
        container: obj,
        onMessage: function (message, origin) {
            this.container.getElementsByTagName("iframe")[0].style.height = message + "px";
            this.container.getElementsByTagName("iframe")[0].style.width = "100%";
        },
        onReady: function () {
            xhr.postMessage(serializer.stringify({
                type: "EchoToken",
                value: echoToken
            }));
            $('.loading-box').hide();
        }
    });
}

var serializer = {
    /**
     * Serializes a hashtable and returns it as a string
     * @param {Object} data The data to serialize
     * @returns The serialized string
     * @type {String}
     */
    stringify: function (data) {
        var message = "";
        for (var key in data) {
            if (data.hasOwnProperty(key)) {
                message += key + "=" + escape(data[key]) + "&";
            }
        }
        return message.substring(0, message.length - 1);
    },
    /**
     * Deserializes a string and returns a hashtable
     * @param {String} message The string to deserialize
     * @returns An hashtable populated with key-value pairs
     * @type {Object}
     */
    parse: function (message) {
        var data = {};
        var d = message.split("&");
        var pair, key, value;
        for (var i = 0, len = d.length; i < len; i++) {
            pair = d[i];
            key = pair.substring(0, pair.indexOf("="));
            value = pair.substring(key.length + 1);
            data[key] = unescape(value);
        }
        return data;
    }
};
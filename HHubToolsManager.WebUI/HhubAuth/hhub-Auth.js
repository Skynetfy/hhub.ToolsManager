//var u;
//try {
//    u = hu || "localhost:51027";
//} catch (e) {
//    u = "localhost:51027";
//}
//var th = top.window.location.href;
//var wh = self.window.location.href;
//if (top.window.location.href !== self.window.location.href) {
//    if (top.window.location.host !== u)
//        DicrectUrl();
//} else {
//    DicrectUrl();
//}

//function DicrectUrl(u) {
//    location.href = "http://localhost:51027/Error";
//}
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

(function () {
    var sr, echoToken, xhr, isLoaded = false, head = document.getElementsByTagName('head')[0];

    function scriptOnLoad() {
        if (isLoaded || typeof easyXDM === "undefined") {
            return;
        }
        isLoaded = true;
        xhr = new easyXDM.Socket({
            swf: "//cdn.bootcss.com/easyXDM/2.4.18.25/easyxdm.swf",
            onMessage: function (message, origin) {
                var data = serializer.parse(message);
                if (data.hasOwnProperty("type"))
                    echoToken = data.value;
                //alert("Received '" + message + "' from '" + origin + "'");
            },
            onReady: function () {
                try {
                    xhr.postMessage(document.body.scrollHeight);
                } catch (e) {
                    // We tried to read the property at some point when it wasn't available
                }
                //socket.postMessage("open");
            }
        });
    }
    sr = document.createElement("script");
    sr.type = "text/javascript";
    sr.src = "//cdn.bootcss.com/easyXDM/2.4.18.25/easyXDM.debug.min.js";
    sr.onreadystatechange = function () {
        if (this.readyState === "complete" || this.readyState === "loaded") {
            scriptOnLoad();
        }
    };
    sr.onload = scriptOnLoad;
    head.appendChild(sr);
})();
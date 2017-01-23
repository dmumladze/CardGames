define([

], function() {
    'use strict';

    if (WebSocketFactory.instance)
        return WebSocketFactory.instance;

    function WebSocketFactory() {
        this.sockets = {}  
    }    

    WebSocketFactory.prototype.create = function(url) {
        var key = url.toLowerCase();
        var ws;
        if ((ws = this.sockets[key]) == null) {
            ws = new WebSocket(url);   
            this.sockets[key] = ws;  
        }
        return ws;
    } 

    WebSocketFactory.instance = new WebSocketFactory();

    return WebSocketFactory.instance;

})

define([

    'app/js/WebSocketFactory'

], function(factory) {
    'use strict';
    
    function BuraController() {
        this.ws = factory.create("ws://" + window.location.host + "/ws/bura");        
        this.ws.onmessage = this.onReceive;
        this.onerror = this.onError;
        this.onclose = this.onDisconnect;
    }

    BuraController.prototype.disconnect = function() {
        this.ws.close();
    }

    BuraController.prototype.onReceive = function(e) {
        console.log(e.data);
    }

    BuraController.prototype.onError = function(e) {
        console.log(e.data);
    }

    BuraController.prototype.onDisconnect = function(e) {
        console.log(e.type);
    }

    BuraController.prototype.onConnect = function(e) {
        console.log(e.type);    
    }

    BuraController.prototype.sendData = function(data) {
        this.ws.send(data);
    }

    return BuraController;

})



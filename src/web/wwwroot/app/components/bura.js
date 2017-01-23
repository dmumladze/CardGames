define([

    'app/js/BuraController'

], function(BuraController) {
    'use strict';
    
    return function(resolve) {        

        require(['text!app/views/bura.html'], function(bura) {

            resolve({
                name: 'bura',
                template: bura,
                data: function() {
                    return {
                        whoami: 'I\'m Bura',
                        controller: new BuraController()
                    }
                },
                methods: {
                    play: function() {
                        this.controller.sendData('Hello');  
                    }
                },
                created: function() {   
                    console.log('created');  
                },
                destroyed: function() {
                    console.log('destroyed');
                } 
            })

        })

    }

})
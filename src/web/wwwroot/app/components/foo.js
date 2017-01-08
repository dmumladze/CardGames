define([

], function() {
    'use strict';

    return function(resolve) {
        require(['text!views/foo.html'], function(foo) {
            resolve({
                name: 'foo',
                template: foo,
                data: function() {
                    return {
                        whoami: 'I\'m Foo'
                    }
                }  
            })
        })
    }

})
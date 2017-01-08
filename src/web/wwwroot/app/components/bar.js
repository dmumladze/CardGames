define([

], function() {
    'use strict';

    return function(resolve) {
        require(['text!views/bar.html'], function(bar) {
            resolve({
                template: bar,

                data: function() {
                    return {
                        whoami: 'I\'m Bar'
                    }
                },
                
                methods: {
                    getGoogle() {
                        var html = this.$http.get('#/foo').then(function(response) {
                                alert(response)
                            })
                    }
                }              
            })
        })
    }

})
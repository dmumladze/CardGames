define([

    'vue',
    'vue-router',

    'axios',

    'com/foo',
    'com/bar'    

], function(Vue, VueRouter, axios, foo, bar) {
    'use strict';

    Vue.prototype.$http = axios

    Vue.use(VueRouter)    

    var routes = [
        { path: '/', component: {} },
        { path: '/foo', component: foo },
        { path: '/bar', component: bar }
    ]

    var router = new VueRouter({
        routes 
    })

    var app = new Vue({
        router
    })

    app.$mount('#app')

})
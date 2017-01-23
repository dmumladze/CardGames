define([

    'vue',
    'vue-router',

    'axios',

    'app/components/bura',
    'app/components/bar'    

], function(Vue, VueRouter, axios, bura, bar) {
    'use strict';

    Vue.prototype.$http = axios

    Vue.use(VueRouter)    

    var routes = [
        { path: '/', component: {} },
        { path: '/bura', component: bura },
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
import Vue from 'vue'
import VueRouter from 'vue-router'

import app from './app.vue'

import routes from './routes'

import authService from './services/auth-service'

if(process.env.NODE_ENV !== 'production') {
    console.log('Development mode started');
}

Vue.use(VueRouter);

const router = new VueRouter({
    routes
});

authService.configRouter(router);
authService.configAxios();

new Vue({
    router,
    render: (h) => h(app)
}).$mount('#app');
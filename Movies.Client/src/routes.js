import login from './pages/login.vue'
import dashboard from './pages/dashboard.vue'
import peliculas from './pages/peliculas.vue'
import personas from './pages/personas.vue'

const routes = [
    {
        name: 'login',
        path: '/login',
        component: login
    },
    {
        name: 'dashboard',
        path: '/',
        component: dashboard,
        meta: { auth: true }
    },
    {
        name: 'peliculas',
        path: '/peliculas',
        component: peliculas,
        meta: { auth: true }
    },
    {
        name: 'personas',
        path: '/personas',
        component: personas,
        meta: { auth: true }
    }
];

export default routes
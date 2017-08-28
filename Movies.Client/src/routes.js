import dashboard from './pages/dashboard.vue'
import pagina1 from './pages/pagina1.vue'
import pagina2 from './pages/pagina2.vue'
const routes = [
    {
        name: 'dashboard',
        path: '/',
        component: dashboard
    },
    {
        name: 'pagina1',
        path: '/pagina1',
        component: pagina1
    },
    {
        name: 'pagina2',
        path: '/pagina2',
        component: pagina2
    }
];

export default routes
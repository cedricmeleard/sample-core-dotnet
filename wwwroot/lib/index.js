const NotFound = { template: '<div><nav-bar-header></nav-bar-header><p>Page not found</p></div>' }
const About = { template: '<div><nav-bar-header></nav-bar-header><about-page></about-page></div>' }
const Home = { template: '<div><nav-bar-header></nav-bar-header><home-page></home-page></div>' }

const routes = {
  '/Homejs/': Home,
  '/Homejs/Index': Home,
  '/Homejs/About': About
}

Vue.component('nav-bar-header', {
  methods: {
    callChangeController: function (controller) {
      app.$emit('changeController', controller);
    }
  },
  template: `
  <header class="main-header">
      <nav>
          <a @click='callChangeController("home")'>Home</a>
          <a @click='callChangeController("about")'>About</a>
      </nav>
  </header>`
})

Vue.component('home-page', {
  data: function () {
    var that = this;
    $.ajax('/api/user/').done(
      function (response) { that.users = response; });
    return {
      message: 'Home page - Power by aspnet Core & VueJs',
      users: null
    };
  },
  template: `
    <div class="animated fadeInRight">
      <div class="container home">
        <div class="wrapper">
          <h1>{{message}}</h1>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
        </div>
        <ul>
          <user-item v-for="user in users" :item="user"></user-item>
        </ul>
      </div>
    <div>`
});

Vue.component('user-item', {
  props: ['item'],
  template: ` <p>Name: {{ item.name }}</p>`
})

Vue.component('about-page', {
  data: function () {
    return {
      message: 'Home page - Power by aspnet Core & VueJs'
    };
  },
  template: `
    <div class="animated fadeInRight">
      <div class="container about">
        <div class="wrapper">
          <h1>{{message}}</h1>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
        </div>
      </div>
    </div>`
});

//app
var app = new Vue({
  el: '#app',
  data: {
    currentRoute: window.location.pathname
  },
  computed: {
    ViewComponent() {
      return routes[this.currentRoute] || NotFound
    }
  },
  render(h) {
    return h(this.ViewComponent)
  }
})

app.$on('changeController', function (controller) {
  switch (controller) {
    case 'home':
      app.currentRoute = '/Homejs/';
      break;
    case 'about':
      app.currentRoute = '/Homejs/About';
      break;
    default:
      app.currentRoute = controller;
  }
  window.history.pushState("", "", app.currentRoute);
})

window.onpopstate = function (event) {
  app.currentRoute = window.location.pathname;
};
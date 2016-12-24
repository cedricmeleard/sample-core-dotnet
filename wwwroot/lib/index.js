const NotFound = { template: '<p>Page not found</p>' }
const About = { template: '<about-page></about-page>' }
const Home = { template: '<home-page></home-page>' }

const routes = {
  '/Homejs/': Home,
  '/Homejs/Index': Home,
  '/Homejs/About': About
}

Vue.component('nav-bar-header', {
  methods : {
      callChangeController : function(controller){
        app.$emit('changeController', controller);
      }
  },
  template : `
  <header class="main-header">
      <nav>
          <a @click='callChangeController("home")'>Home</a>
          <a @click='callChangeController("about")'>About</a>
      </nav>
  </header>`
})

Vue.component('home-page', {
  data : function(){
    return {
      message : 'Home page - Power by aspnet Core & VueJs'
    };
  },
  template : `
    <div>
      <nav-bar-header></nav-bar-header>
      <div class="animated fadeInRight">
        <div class="container home">
          <div class="wrapper">
            <h1>{{message}}</h1>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
          </div>
        </div>
      </div>
    <div>`
});

Vue.component('about-page', {
  data : function(){
    return {
      message : 'Home page - Power by aspnet Core & VueJs'
    };
  },
  template : `
    <div>
      <nav-bar-header></nav-bar-header>
      <div class="animated fadeInRight">
        <div class="container about">
          <div class="wrapper">
            <h1>{{message}}</h1>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum ullam, corporis ad, necessitatibus excepturi consectetur aliquam, doloremque omnis ea architecto atque numquam reiciendis incidunt. Mollitia voluptatibus hic, eaque a quibusdam.</p>
          </div>
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
    ViewComponent () {
      return routes[this.currentRoute] || NotFound
    }
  },
  render (h) { 
    return h(this.ViewComponent) 
  }
})

app.$on('changeController', function(controller){
  switch(controller){
    case 'home':
      app.currentRoute = '/Homejs/';
      break;
    case 'about' :
      app.currentRoute = '/Homejs/About';
      break;
    default:
      app.currentRoute = controller;
  }
  window.history.pushState("", "", app.currentRoute);
})
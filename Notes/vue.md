# Installiation commands

```bash
npm install vite@latest
npm init vite@latest project_name -- --template vue
cd project_name
npm install
npm install -D tailwindcss@latest postcss@latest autoprefixer@latest vue-router
npx tailwindcss init -p
```

```bash
npm create vuetify@latest
```

# tailwind.config.js:

```javascript
export default {
    content: [],
    purge: {
        enabled: true,
        content: ['./public/**/*.html', './src/**/*.vue', './src/**/*.js'],
    },
    theme: {
        extend: {},
    },
    plugins: [],
};
```

# main.js:

```javascript
import { createApp } from 'vue';
import './style.css';
import router from './router/router.js';
import App from './App.vue';

createApp(App).use(VueCookies).use(router).mount('#app');
```

# style.css:

```css
@tailwind base;
@tailwind components;
@tailwind utilities;

:root {
    line-height: 1.5;
    font-weight: 400;

    color-scheme: light dark;
    color: rgba(255, 255, 255, 0.87);

    margin: 0;
    padding: 0;
    background: url('./assets/asd2.jpg') no-repeat center center fixed;
    background-size: cover;

    font-synthesis: none;
    text-rendering: optimizeLegibility;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    html,
    body {
        height: 100%;
        width: 100%;
    }
}
```

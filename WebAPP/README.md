# Euroaquaing - Web page

## Usage

+ Install node

+ We need some tools to install, with node package manage.

We need to install bower and gulp globally (-g).

```
npm install -g bower gulp
```

npm is package manager (mostly) for non-client side JS, ex. for dev tools as gulp and gulp's plugins. (see package.json)

Bower is package manager for client side JS. Packages that we install with bower we can use in our page, ex. angular, animate.css, moment, etc. (see bower.json).

Gulp is tool for task automation.

+ Go to this folder in terminal and install dependencies with npm and bower

```
npm install
bower install
```

+ Run ```gulp serve``` and wait for page to open in browser. All files are watched and if you change them browser will reload and show changes.

More about what gulp do, you can find [here](https://github.com/swiip/generator-gulp-angular/blob/master/docs/usage.md#features-included-in-the-gulpfile ).

But basically, just open terminal in this folder, run ```gulp serve``` and code :D

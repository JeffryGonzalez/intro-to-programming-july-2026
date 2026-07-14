# Angular

## Creating an Angular App

Use the Angular CLI

The Angular CLI (ng) is "global"

```sh
npm i -g @angular/cli
```

## To start an angular app:

```sh
ng serve

// or, using npm
npm run start
```

### Compilation starts at the entry point

`/src/main.ts`

### Components

Your whole angular application lives in a component called (by convention) `app.ts`.

Every other component is a "child" of this component.

Components can be added by using their selector, or by using the router, or dynamically (programatically added.)

Components are in a hierarchy. Components live in other components.

Parents can pass data to an immediate child with an `input()` (the child declares the input)

Parents can respond to events in an immediate child with an `output()` - the child signals that something
happened to the parent.

Parent components cannot access their grandchildren. (sad)

Sibling components can't talk to each other.

State (data) should be in Signals. We've done a bunch of this. Tomorrow I'll tell you why, and show you more cool stuff. It's easy, but this is still relatively new in Angular.

- old angular apps would pretend to use "raw" variables and used a tool called "zone.js" to create the illusion.
- for asynchronous stuff we used the Reactive Extensions for JavaScript (RXJS) - still can and will be used, but really a pain.

For sharing functionality beyond these limits of inputs and outputs you
define a class or function that is responsible for some data, and all the behavior around that data. You know. a **service**, and the services are _injected_ in to components or other services (like `IDocumentSession` last week).

## Differences

- React "Just trying to be the V in MVC" - very simple. Functional. JS or TS.
  - React has an AMAZING ecosystem. Lots of great libraries, etc.
    - Tanstack stuff is _dreamy_ (router, query, etc. )
- Vue - JS or TS.
  Really is the sweet spot between function and easy.

- Angular
  - Negative - components are a bit verbose.
  - Negative - not quite as big of a an open-source community (NGRX, NG-Neat, Angular Architects)
  - Positives - MUCH less dependency hell between versions, the `ng update` is HAWTNESS
  - Positive - It's google, and they do good "build" - you get REALLY small html, JS, etc. that performs well.
  - Angular Router is pretty mid. It is the NEXT thing they are updating to signals.
  - Forms - we have three ways to do forms, and two of them suck.
    - Template forms. At the beginning of Angular 2, nobody uses this.
    - Reactive forms - use RXJS, observables, really complicated, hard to extend and generalize.
    - As of Angular 22 - Signal Forms - FANTASTIC - best of any framework. Perfect. Chef kiss. No Notes.

- Svelte and SolidJS - these are _great_, and also have the benefit of not _just_ being for "SPAs" - you
  can create nice little experiences that live inside server-side apps with these (easier than Angular, Vue, React).

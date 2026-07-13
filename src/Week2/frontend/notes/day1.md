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

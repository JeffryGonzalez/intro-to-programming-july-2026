# The Shows API

Jeff Was Here

We are creating an HTTP (Web) API that allows an application to add a suggested show to watch,
a way to retrieve that show, and a list of all shows.

More features later.

## HTTP 

HTTP is an "application layer protocol" that lives on top of the TCP protocol.

TCP has lots of applications that use it (mail, SSH, telnet, etc.etc.) each running TCP application gets a "port" assigned to it.

- ssh: 22
- http: 80
- https: 443

(Configuration is the part of your application that changes depending on where it runs).


## Getting a List of Shows

To retreive a list of shows, use this:
(use `GET` to, uh, GET a representation of that resource)

```http
GET https://localhost:1337/shows
Accept: application/json
```


## Adding a Show

To add a show:
(use a post (on a collection) to say "please consider making this a subordinate resource to shows")

```http
POST https://localhost:1337/shows 
Content-Type: application/json 

{
    "title": "Silo"
}
```

## Getting a single show

```http
GET https://localhost:1337/shows/70a93513-f422-49cb-bcf8-1f6831afac4d
```
# Summary of Week One

This is not a summary of *everything* we did. You have the code, the notes, and all my wonderful drawings for that. Also, you have my course materials:

See the course materials here: https://class.hypertheory-labs.com/course/intro-prog/ - as you can see, there is a lot there that we've done, and we have a bit of a way to go.

## Services and SOA

We started off talking about services. Sort of jumped into the deep end of the pool and build an HTTP-based (Web, RESTful) API for shows. In this API we used the "controller-less" approach. Next week we'll do an API with controllers. Both are created here, and you should recognize both.

`Program.cs` is the *entry point* - it is what runs when your application start. It is broken into two sections. The top part, before the `app` is built, is opting in for various *services* that you want to avail yourself to in your code within this application. For example, we added `Marten`, and the `ShowsData` service. After the app is built, we configure our application to handle requests and responses. This is where we added our endpoints for Shows.

> **Important Point**: Configuration is what changes when you change environments. Avoid storing configuration information in your application repository. Use techniques like environment variables for things like connection strings (Aspire does this for you automatically).

A huge amount of work done at your company is based around HTTP-based services. 

> **Question**: What is the advantage of using HTTP over other protocols, like gRPC, etc.?
> HTTP is slow. It's constrained - request/response, stateless, etc.
Very standard - has a lot built in, https (TLS).
Very standard - proven, and ubiquitious - everything supports http.



> **Question**: Why do we set a port for our local API to run on (e.g. 1337)?
TCP (the protocol) can run many applications and each one needs a unique port.
You might have several APIs running on your machine - each one needs a unique port.


### Testing

We did manual testing at first [Design.md](../src/ShowsSolution/design.md). We just created HTTP request messages and sent them to see the response. Manual testing is cool and very useful. Teams use tools like "Postman" (a piece of commercial software) for doing manual testing like this.

We created some automated "Systems Tests", meaning we set it up so that we can reliably test to make sure the functionality we are offering through our service works properly, and that we don't accidentally alter it in the future. Systems Tests mean testing your application "as a whole", with any external dependencies your team doesn't control stubbed or mocked. 

For our API, we wrote a sample test that uses an HTTP post to add a new show to the database, and then we made another HTTP request to GET all of the shows to verify our new show was added. This was a pretty simple test, and your tests will often (always?) be more involved. We hinted at that in TDD Kata-2 - Interaction tests. We'll do a *bit* more next week as well.

While most of your testing effort as a developer should be in systems testing, we spent a lot of time writing unit tests and practicing Test-Driven Development to get both the experience of thinking about code in terms of testable functionality, as well as creating sustainable work for iterative development and release.

### DevOps 

We started touching on some of your responsibilities for smoothly and reliably moving code through environments. Configuration, pipelines (CI/CD), testing, etc. At the end of next week we will make this more "real".

### Containers

We used containers for our database. Containers are a great addition to a developers toolkit, but they are primarily used as a target for *delivering* our software. We will learn more about this next week.

### Coupling and Cohesion

We spent a lot of time thinking about the structure and "style" of our code. Not really in an aesthetic sense, more in terms of how we could think about writing code that many developers over a long period time will be working with.

- Four Rules of Simple Design
  - Especially "expresses intent". It does not mean you have to write overly verbose or flowery code or comments, but another developer should be able to look at your code and tests and understand what that code does as well as what it *represents*. What is the difference? What it represents is something like "business policy". Certain accounts get bonuses on deposits. Code like that has to be related to, we could say "grounded" in reality *outside* of the software you are writing. That code represents our understanding of a business practice or policy. We could be right or wrong about it, it can change in the future, etc. but we need to be able to locate it, understand it, etc. Our tests - especially System Tests - should "point" clearly to these kind of business or technical requirements. The more we can thoroughly test at that level, the better off we are. Testing at the "how we do it" level tends to lock in a specific approach. Sometimes you really do need very low-level verification of an algorithm, etc. Sometimes you don't. It takes experience. Ask lots of questions. Ask you AI. Ask your mentor. Ask you cat. Talking out loud helps.
- Cohesion
  - How well things "go together". It's why bonus calculation maybe shouldn't be a part of a bank account. That's another responsibility. Cohesion is challenging. See https://en.wikipedia.org/wiki/Cohesion_(computer_science) - (I don't like that it calls on form "best" - but whatever)
  - Writing tests from the POV of the consumer of your application tends to help with cohesion.
  - You structure your code based on *use* more than some intellectual or white-board model of the code.
  - We also decided, for example, that checking to see if a transaction amount is in a valid range (>0) wasn't *cohesive* with an Account. We created a *thing* called `TransactionAmount`. Was I trying to teach you how to create a specific implementation, implicit conversions, etc.? Yeah, a little bit because it's cool and I like cool things. **The most important thing though is you develop the ability to start noticing when things are no longer cohesive. When things start looking messy, resist the temptation to "brute force" it. Step back, and see what concepts are missing**.
- Coupling - this is *huge*. Very important. I told you that coupling is the strength of relationships between code modules. If you change one, it shouldn't impact the other. Changes to how bonus calculation are done don't require a change in the deposit method in the account. **It's not as easy as I make it seem**. I tried to simulate as much as I can in the limited time we have ways that coupling issues more naturally reveals themselves to you. For example, when we put the somewhat trivial algorithm for calculating bonuses in the `Deposit` method, every time those changed it changed the behavior of our account. This was showing us that we were treating an Account as synonymous with "Bonus Calculation". That doesn't even sound right when you say it out loud, right? Bonus calculation is a worthy concept to have it's own name, identity, within a banking institution. So that is cohesion. Coupling was our decision to make the account rely on a job description, not a particular instance of a bonus calculator. **It's way harder to get overly attached (coupled) to something when you don't even know what it really is**. Our account relied on a "job description" - something that could calculate bonuses. It doesn't really know what that means, except sort of abstractly, but it knows it needs to use it. ("rely on abstractions not concretions").
- In *some* applications we treat service lifetime and selection a first-class concept in our application. With the bank account we did that through constructor injection. In APIs, Angular, etc. we do it through configuring service providers. Much, much more on this next week.


> **Question**: What was the string calculator (TDD Kata 1) all about? 

One step at a time! Avoiding overworking - doing more than is needed, beccause we have to prove
first that we are thinking right about the problem and that this is the right solution.

Incremental small steps.

> **Question**: What was the string calculator (TDD Kata 2) all about? 

Coupling. Interactions - verifying the code you are responsible for interacts with other code in the way
you expect.

Site Reliability / Chaos etc. 

"When the logger throws an exception, do this other thing..."


> **Question**: Why do we say "hold your breath until you get to green" when doing TDD? What's that all about?  

Break your code into little things that are understandable and express intent.


> **Question**: True or false: Tests prove our code runs correctly. 

False. BE SMART ABOUT WHAT TESTS YOUR WRITE.

> **Question**: True or false: The more tests the better. And why is that false. 

False - bugs scale linearly with the number of lines of code.

> **Question**: Why do we, as programmers, prefer small little things (classes, methods, services, etc.) over big things? 

"Fits in your head" - "Cognitive Crutch" 

Don't worry about reuse. Be selfish. 

> **Question**: Why would you do an "extract method" refactoring?  

Don't do it expecting reuse - do it to make it more understandable and to NAME THINGS THAT ARE LATENT IN THE CODE.

> **Question**: True or false: as an application developer, you should always write your code expecting reuse by your team. Make sure your write "bomb proof" code that validates every input, because every one is dumb but you. 

Old skool - AND if you are writing libraries/frameworks, etc. Not application development.

> **Question**: What is an "Application Developer"? Are application developers that produce the most code the better application developers than those that produce very little?

"Applying" - using technology in novel ways to provide business value or reduce liability.

Not writing code. 



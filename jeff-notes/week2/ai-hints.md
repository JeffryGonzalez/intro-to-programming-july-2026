# Using AI

- Environments
- Debugging
  - contradictions
    - our understanding of what the code does does not align with the behavior of the code.
    - Write two _temporary_ tests (explanations).
      - The first one is a test that shows how the code should work (expectations)
      - The second one is how it currently works
    - What are the failure modes? What should about here?
      - What tests am I missing?
    - Changing code without tests is playing russian roulette. Add tests to any code you are going to change.

- "Agent Mode"
  - Chat - you can talk to it.
  - Agent - it can do things (has "agency")
    - I do not trust myself to review every request for it to do something.
    - I don't put AI in "YOLO" mode (everything goes) in non-isolated environment.
    - You can get REALLY close with containers.
  - "Planning" - The idea is don't do anything, just talk through it. I think it is pretty BS most of the time.
  - "Agents" - Hermes

Michael Feathers "Working Effectively with Legacy Code"

- Any code that doesn't have tests.
  - You are scared to change it because it is important and you rely upon it.
  - But you _need_ to change it (bugs, updates, etc)

- Find what's wrong with your understanding
  - "IDGAS - FIX IT!" QUIT TREATING SOFTWARE AS SOME FOREIGN PUZZLE THAT CANNOT BE UNDERSTOOD - that's what got us here in the first place.
  - Ask the AI to help you minimize the blast radius of any changes you might make.
  - Be willing to work on a "throw away" copy of the code just to dissect it and figure out the problem.

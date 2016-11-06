# Developer Test
Objective 3 - Review the existing code
Good Things

1. Used DI Container for Injection DBContext which helps to UnitTest the Code easily by mocking context and also easy to replace it in future.
2. All the functionalities of Website is maintained as Command and handler which is clear to understand and maintain.

Few Refactor Suggestions:

1. Seperate Business Logic (CommandHandler etc) in seperate Layer.
2. Seperate Model from UI(Web) so that it can be re-used and also easy to replace Database access layer in future in case.
3. Comman functionality of command handler can be placed in base class.
4. It is always good to have logging Filter to log all the actions so that it will be easy for Auditing.



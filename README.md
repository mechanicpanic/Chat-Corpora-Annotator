# Chat-Corpora-Annotator
This is my frist try at implementing a chat dataset viewer and corpus (tagged dataset) creator in a standalone project. This has been mostly done for my 2020 undergrad thesis at SPbU. After that, we have cooperated with Evgeniy Slobodkin to include his ANTLR4 parser for the Matcher query language into the project. The theoretical work has been done under the guidance of George Chernishev.


Simple instructions:

1. CCA saves all its data in \username\CCA.
2. To use CoreNLP extracting functionality, you will have to download the Models folder and put the contents into CCA\Models.
3. Use the Extract menu item to load the CoreNLP annotations into memory.


`Suggester` manual:
This window is intended for using our query language Matcher. It is based on Boolean retrieval model and pattern matching, and its main purpose is to select *groups* of messages wrapped in *suggestions*: as in, the query language allows the user to select `n` messages, which are then wrapped in their context in the dataset. This is intended to help the user select *situations*: explained in a future paper.
Operators:
0. `select` - Start a query or a subquery.
1. `(`, `)`: Subqueries have to be surrounded by parentheses. Can also be used in Boolean retreival.
2. `;`: Separator for subqueries.
3. `and`, `or`, `not`: Boolean operators.
4. `haswordofdict()`: Select messages where any word from a user defined dictionary occurs.
5. `byuser()`: Select messages by a specified username.
6. `hasusermentioned()`: Select messages which mention a username. Currently does not consider the "to" field, which is optional in our data schema.
7. `hasdate()`: Select messages that have a DATE CoreNLP NER tag
8. `hastime()`: TIME CoreNLP NER tag
9.  `haslocation()`:LOCATION CoreNLP NER tag
10. `hasorganization()`: ORGANIZATION CoreNLP NER tag
11. `,`: Operator separator for group construction
12. `inwin n`: This operator is used to constrain the search as follows: `select haswordofdict(a), haswordofdict(b) inwin 5` selects groups in which the second message that contains a word from `b` can only be found 5 messages down or less from the first one.

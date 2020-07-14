# Chat-Corpora-Annotator
This is my 2020 undergrad thesis + Eugene Slobodkin's ANTLR4 parser. The theoretical work has been done under the guidance of George Chernishev.

Simple instructions:

1. CCA saves all its data in \username\CCA.
2. To use CoreNLP extracting functionality, you will have to download the Models folder and put the contents into CCA\Models.
2.1 Use the Extract menu item to load the CoreNLP annotations into memory.

The See suggestions manual:

This window is intended for using our query language (Matcher).
Operators:
1. haswordofdict() - Select messages where any word from a user defined dictionary occurs.
2. byuser() - Select a username
3. hasusermentioned() - Select messages which mention a username. Currently does not consider the "to" field, which is optional
4. hasdate() - Has a DATE CoreNLP NER tag
5. hastime() - Has a TIME CoreNLP NER tag
6. haslocation() - Has a LOCATION CoreNLP NER tag
7. hasorganization() - Has an ORGANIZATION CoreNLP NER tag
8. inwin n - in window of n messages

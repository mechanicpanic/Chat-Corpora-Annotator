grammar Chat;

query
    :
    Select body
    ;

body
    :
    restriction_group (',' restriction_group)*
    ;

restriction_group
    :
    restrictions InWin number
    | restrictions
    ;

restrictions
    :
    restriction (',' restriction)*
    ;

restriction
    :
    restriction And restriction
    | restriction Or restriction
    | '(' restriction ')'
    | Not restriction
    | condition
    ;

condition
    :
    HasWordOfDict '(' hdict ')'
    | HasTime '(' ')'
    | HasLocation '(' ')'
    | HasOrganization '(' ')'
    | HasURL '(' ')'
    | HasDate '(' ')'
    | HasQuestion '(' ')'
    | HasUserMentioned '(' huser ')'
    | ByUser '(' huser ')'
    ;

hdict : STRING;
huser : STRING;
number : INTEGER;

Select : 'SELECT' | 'select';
InWin  : 'INWIN'  | 'inwin' ;
Not    : 'NOT'    | 'not'   ;
And    : 'AND'    | 'and'   ;
Or     : 'OR'     | 'or'    ;

HasWordOfDict    : 'HASWORDOFDICT'    | 'haswordofdict'   ;
HasTime          : 'HASTIME'          | 'hastime'         ;
HasLocation      : 'HASLOCATION'      | 'haslocation'     ;
HasOrganization  : 'HASORGANIZATION'  | 'hasorganization' ;
HasURL           : 'HASURL'           | 'hasurl'          ;
HasDate          : 'HASDATE'          | 'hasdate'         ;
HasQuestion      : 'HASQUESTION'      | 'hasquestion'     ;
HasUserMentioned : 'HASUSERMENTIONED' | 'hasusermentioned';
ByUser           : 'BYUSER'           | 'byuser'          ;

STRING  : (LETTER | DIGIT)+;
INTEGER : DIGIT+;

WS: [ \n\r\t] -> skip;

fragment DIGIT : [0-9];
fragment LETTER : [a-zA-Z_];

// SELECT haswordofdict("animals")
// SELECT haswordofdict("animals") AND haswordofdict("medicine")
// SELECT haswordofdict("animals") AND haswordofdict("medicine"), haswordofdict("qualities") INWIN 5
// SELECT haswordofdict("animals") AND haswordofdict("medicine"), haswordofdict("qualities") INWIN 5, haswordofdict("pharmacies") INWIN 5
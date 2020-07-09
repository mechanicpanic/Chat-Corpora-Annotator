grammar Chat;

query
    :
    Select body
    ;

body
    :
    restriction_expr (',' restriction_expr)*
    ;

restriction_expr
    :
    restriction InWin number
    | restriction
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
HasLocation      : 'HASLOCATION'      |  'haslocation'    ;
HasOrganization  : 'HASORGANIZATION'  | 'hasorganization' ;
HasUserMentioned : 'HASUSERMENTIONED' | 'hasusermentioned';
ByUser           : 'BYUSER'           | 'byuser'          ;

STRING  : '"' LETTER+ '"';
INTEGER : DIGIT+;

WS: [ \n\r\t] -> skip;

fragment DIGIT : [0-9];
fragment LETTER : [a-zA-Z];

// SELECT haswordofdict("animals")
// SELECT haswordofdict("animals") AND haswordofdict("medicine")
// SELECT haswordofdict("animals") AND haswordofdict("medicine"), haswordofdict("qualities") INWIN 5
// SELECT haswordofdict("animals") AND haswordofdict("medicine"), haswordofdict("qualities") INWIN 5, haswordofdict("pharmacies") INWIN 5
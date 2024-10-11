# Hierarchical Injection


## General concept

Any class will get a created partial class with a ctor that injects all public classes in the folder directly under itself. 
* If a class needs additional injections it can be annotated with an attribute that includes additional classes in the ctor.
* If a class should be opted out it can be annotated with an attribute that ignores it.

## Considerations

* Should there be included lifetime?






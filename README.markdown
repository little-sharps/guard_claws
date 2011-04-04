guard_claws ![Project status](http://stillmaintained.com/littlebits/guard_claws.png)
=========

Install via [NuGet](http://www.nuget.org/List/Packages/guard_claws).

A DRY guard clause library designed to provide simple, readable guard clauses. Inspired by this [question on StackOverflow]( http://stackoverflow.com/questions/669678/what-is-the-smoothest-most-appealing-syntax-youve-found-for-asserting-parameter/670495).

Example
==============

NotNullNotBlank
----

    var test = string.Empty;
    Claws.NotNullNotBlank(() => test);
 
Will throw:
 
    GuardClaws.Exceptions.VariableMustNotBeBlankException was unhandled
      Message="Variable must not be blank./n/nDelinquent: test"
      Source="guard_claws"
      NameOfDelinquent="test"

Performance
===========

guard_claws uses code from the [Lokad Shared Libraries](http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html) to gain access to the name of the parameter without having to resort to expressions and the runtime costs compiling them incurs. 

License
===========
Copyright (c) 2011, Brendan Erwin and contributors.
All rights reserved.
 
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    
  * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
  * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
  * The names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY Brendan Erwin and contributors ''AS IS'' AND ANY
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL Brendan Erwin or contributors BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

---------------------------

Some Portions of this code are  Copyright (c) Lokad 2009 Company: http://www.lokad.com 
and are also licensed under the New BSD License.
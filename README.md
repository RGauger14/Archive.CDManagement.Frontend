# Archive.CDManagement.Api

For generating fake data.
https://www.json-generator.com/
```json
[
  '{{repeat(5, 7)}}',
  {
    title: '{{lorem(10, "words")}}',
    author: '{{firstName()}}',
    section: '{{random("A", "B", "C", "D")}}',
    x: '{{integer(1, 100)}}',
    y: '{{integer(1, 100)}}',
    barcode: '{{integer(1, 100)}}',
    description: '{{lorem(10, "words")}}',
    onLoan: '{{bool()}}'
  }
]
```
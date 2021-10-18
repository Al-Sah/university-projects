# sorting algorithms benchmarks  (C++)


<table>
  <tr>
    <td></td>
    <td>bubble sort</td>
    <td>shaker sort</td>
    <td>shaker sort (stop on ready)</td>
  </tr>
  <tr>
    <td>standard</td>
    <td>
        <ol>
            <li>size: 10 000;  time: 94 ms</li>
            <li>size: 150 000; time: 28197 ms</li>
            <li>size: 500 000; time: 321.83 sec </li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 80 ms</li>
            <li>size: 150 000; time: 23102 ms</li>
            <li>size: 500 000; time: 266.65 sec </li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 75 ms</li>
            <li>size: 150 000; time: 21304 ms</li>
            <li>size: 500 000; time: 235.45 sec</li>
        </ol>
    </td>
  </tr>
  <tr>
    <td>temp storage  </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 99 ms</li>
            <li>size: 150 000; time: 30507 ms</li>
            <li>size: 500 000; time: 349.54 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 88 ms </li>
            <li>size: 150 000; time: 24774 ms </li>
            <li>size: 500 000; time: 267.5 sec </li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 75 ms</li>
            <li>size: 150 000; time: 21387 ms</li>
            <li>size: 500 000; time: 234.93 sec</li>
        </ol>
    </td>
  </tr>
  <tr>
    <td>arithmetic</td>
        <td>
        <ol>
            <li>size: 10 000;  time: 89 ms</li>
            <li>size: 150 000; time: 27951 ms</li>
            <li>size: 500 000; time: 322.42 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 82 ms</li>
            <li>size: 150 000; time: 23647 ms</li>
            <li>size: 500 000; time: 258.44 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 76 ms</li>
            <li>size: 150 000; time: 21297 ms</li>
            <li>size: 500 000; time: 240.36 sec</li>
        </ol>
    </td>
  </tr>
  <tr>
    <td>inline temp storage</td>
        <td>
        <ol>
            <li>size: 10 000;  time: 91 ms</li>
            <li>size: 150 000; time: 28573 ms</li>
            <li>size: 500 000; time: 324.47 sec </li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 81 ms</li>
            <li>size: 150 000; time: 22582 ms</li>
            <li>size: 500 000; time: 250.38 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 75 ms</li>
            <li>size: 150 000; time: 21239 ms</li>
            <li>size: 500 000; time: 238.22 sec</li>
        </ol>
    </td>
  </tr>
  <tr>
    <td>inline arithmetic</td>
        <td>
        <ol>
            <li>size: 10 000;  time: 88 ms</li>
            <li>size: 150 000; time: 28893 ms</li>
            <li>size: 500 000; time: 325.89 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 80 ms</li>
            <li>size: 150 000; time: 23035 ms</li>
            <li>size: 500 000; time: 251.99 sec</li>
        </ol>
    </td>
        <td>
        <ol>
            <li>size: 10 000;  time: 75 ms</li>
            <li>size: 150 000; time: 21364 ms</li>
            <li>size: 500 000; time: 233.13 sec</li>
        </ol>
    </td>
  </tr>
</table>


### Tested with following parameters:

|   Option              |  Value
| --------------------- | -------
| Operating system      | Xubuntu
| Ubuntu version        | 9.3.0-17ubuntu1~20.04
| Architecture          | x86_64
| CPU                   | AMD Ryzen 5 3400G with Radeon Vega Graphics
| RAM                   | DDR4 16G (2x); Speed: 2800 MT/s
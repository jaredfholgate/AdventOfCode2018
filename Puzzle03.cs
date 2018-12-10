﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace AdventOfCode
{
  public class Puzzle03
  {
    public static void Run1()
    {
      var area = new Dictionary<int, Dictionary<int, int>>();
      for(var i = 0; i <= 1000; i++)
      {
        var column = new Dictionary<int, int>();
        for (var ii = 0; ii <= 1000; ii++)
        {
          column.Add(ii, 0);
        }
        area.Add(i, column);
      }
      var input = ParseInput();
      foreach (var key in input.Keys)
      {
        for (var i = input[key].X; i < input[key].X + input[key].Width; i++)
        {
          for (var ii = input[key].Y; ii < input[key].Y + input[key].Height; ii++)
          {
            area[i][ii] += 1;
          }
        }
      }

      var count = 0;
      foreach (var key in area.Keys)
      {
        foreach (var key2 in area[key].Keys)
        {
          if (area[key][key2] > 1)
          {
            count++;
          }
        }
      }
      Console.WriteLine(count);
    }
    public static void Run2()
    {
      var area = new Dictionary<int, Dictionary<int, int>>();
      for (var i = 0; i <= 1000; i++)
      {
        var column = new Dictionary<int, int>();
        for (var ii = 0; ii <= 1000; ii++)
        {
          column.Add(ii, 0);
        }
        area.Add(i, column);
      }
      var input = ParseInput();
      foreach (var key in input.Keys)
      {
        for (var i = input[key].X; i < input[key].X + input[key].Width; i++)
        {
          for (var ii = input[key].Y; ii < input[key].Y + input[key].Height; ii++)
          {
            area[i][ii] += 1;
          }
        }
      }

      foreach (var key in input.Keys)
      {
        bool hasOverlap = false;
        for (var i = input[key].X; i < input[key].X + input[key].Width; i++)
        {
          for (var ii = input[key].Y; ii < input[key].Y + input[key].Height; ii++)
          {
            if (area[i][ii] > 1)
            {
              hasOverlap = true;
            }
          }
        }
        if (!hasOverlap)
        {
          Console.WriteLine(key);
          break;
        }

      }
    }

    public class Coordinate
    {
      public int X { get; set; }
      public int Y { get; set; }

      public int Width { get; set; }

      public int Height { get; set; }
    }

    private static Dictionary<int, Coordinate> ParseInput()
    {
      var result = new Dictionary<int, Coordinate>();
      foreach (var line in Input().Split(Environment.NewLine))
      {
        var split = line.Replace(" ", String.Empty).Replace("#", string.Empty).Split(new[] {'@', ':'});
        var id = Convert.ToInt32(split[0]);
        var coordinate = new Coordinate() { X = Convert.ToInt32(split[1].Split(',')[0]), Y = Convert.ToInt32(split[1].Split(',')[1]), Width = Convert.ToInt32(split[2].Split('x')[0]), Height = Convert.ToInt32(split[2].Split('x')[1]) };
        result.Add(id, coordinate);
      }
      return result;
    }


    public static string Input()
    {
  return @"#1 @ 520,746: 4x20
#2 @ 274,680: 19x26
#3 @ 928,402: 16x24
#4 @ 338,969: 27x15
#5 @ 48,306: 21x16
#6 @ 418,87: 13x20
#7 @ 271,316: 16x20
#8 @ 697,513: 20x25
#9 @ 120,479: 28x13
#10 @ 974,8: 17x12
#11 @ 615,355: 11x29
#12 @ 687,970: 20x29
#13 @ 176,605: 24x11
#14 @ 512,252: 11x11
#15 @ 839,821: 20x10
#16 @ 242,267: 29x14
#17 @ 702,795: 11x14
#18 @ 695,516: 14x18
#19 @ 108,169: 28x12
#20 @ 13,973: 27x18
#21 @ 1,580: 14x28
#22 @ 319,694: 19x27
#23 @ 149,828: 11x23
#24 @ 619,935: 11x26
#25 @ 727,746: 6x3
#26 @ 808,336: 21x17
#27 @ 71,335: 10x17
#28 @ 335,307: 16x19
#29 @ 524,551: 18x17
#30 @ 486,831: 16x28
#31 @ 193,548: 22x29
#32 @ 29,815: 20x18
#33 @ 719,847: 26x24
#34 @ 721,350: 19x18
#35 @ 870,260: 10x20
#36 @ 246,702: 29x27
#37 @ 342,892: 16x22
#38 @ 919,512: 25x13
#39 @ 646,154: 23x13
#40 @ 573,181: 21x25
#41 @ 175,929: 29x17
#42 @ 694,104: 10x13
#43 @ 778,869: 27x21
#44 @ 296,748: 23x29
#45 @ 139,481: 29x18
#46 @ 228,790: 29x23
#47 @ 497,517: 12x24
#48 @ 753,926: 12x11
#49 @ 234,780: 17x28
#50 @ 932,553: 12x17
#51 @ 584,9: 12x20
#52 @ 57,516: 29x28
#53 @ 788,669: 29x18
#54 @ 188,303: 25x20
#55 @ 281,262: 20x28
#56 @ 98,714: 28x11
#57 @ 900,534: 12x22
#58 @ 660,720: 27x10
#59 @ 754,940: 25x27
#60 @ 867,499: 23x24
#61 @ 0,941: 16x10
#62 @ 855,807: 10x23
#63 @ 122,283: 22x19
#64 @ 940,539: 15x22
#65 @ 223,971: 22x26
#66 @ 784,516: 21x26
#67 @ 395,354: 13x28
#68 @ 566,199: 25x18
#69 @ 78,648: 3x15
#70 @ 11,971: 18x11
#71 @ 442,407: 5x17
#72 @ 224,61: 24x14
#73 @ 71,380: 26x28
#74 @ 528,411: 26x14
#75 @ 653,973: 19x25
#76 @ 76,329: 12x18
#77 @ 59,295: 11x22
#78 @ 597,430: 18x25
#79 @ 512,533: 28x23
#80 @ 523,946: 20x17
#81 @ 485,575: 10x26
#82 @ 455,563: 16x29
#83 @ 450,846: 13x17
#84 @ 305,601: 19x22
#85 @ 579,715: 7x16
#86 @ 553,26: 25x21
#87 @ 593,174: 21x16
#88 @ 551,427: 12x16
#89 @ 581,266: 22x13
#90 @ 362,647: 12x18
#91 @ 209,850: 12x15
#92 @ 483,327: 12x12
#93 @ 570,825: 10x15
#94 @ 598,903: 14x28
#95 @ 248,136: 11x16
#96 @ 94,631: 13x23
#97 @ 230,226: 16x23
#98 @ 737,891: 13x18
#99 @ 720,613: 26x15
#100 @ 62,620: 23x14
#101 @ 81,716: 24x24
#102 @ 646,657: 10x15
#103 @ 661,247: 22x28
#104 @ 534,265: 19x22
#105 @ 527,277: 14x11
#106 @ 201,166: 17x20
#107 @ 492,220: 27x25
#108 @ 682,798: 22x21
#109 @ 420,367: 11x11
#110 @ 945,223: 13x25
#111 @ 358,886: 29x16
#112 @ 117,417: 12x24
#113 @ 138,88: 26x18
#114 @ 586,144: 12x28
#115 @ 451,87: 18x10
#116 @ 44,656: 14x23
#117 @ 914,694: 26x23
#118 @ 330,329: 13x28
#119 @ 375,739: 22x18
#120 @ 960,829: 10x19
#121 @ 1,610: 14x19
#122 @ 827,527: 12x16
#123 @ 867,668: 27x28
#124 @ 838,70: 4x8
#125 @ 329,576: 15x17
#126 @ 160,874: 26x19
#127 @ 722,563: 22x29
#128 @ 545,419: 18x27
#129 @ 339,506: 10x17
#130 @ 96,931: 21x10
#131 @ 777,497: 27x23
#132 @ 841,346: 24x23
#133 @ 309,625: 10x24
#134 @ 543,429: 21x15
#135 @ 404,388: 28x26
#136 @ 872,173: 10x24
#137 @ 170,894: 26x12
#138 @ 73,643: 10x14
#139 @ 186,651: 28x15
#140 @ 61,344: 22x19
#141 @ 744,966: 22x27
#142 @ 387,78: 10x15
#143 @ 205,923: 14x24
#144 @ 83,859: 17x19
#145 @ 608,492: 18x19
#146 @ 499,754: 23x29
#147 @ 520,311: 23x22
#148 @ 915,489: 27x23
#149 @ 566,608: 23x15
#150 @ 242,946: 25x20
#151 @ 952,425: 28x10
#152 @ 676,57: 11x29
#153 @ 744,719: 22x11
#154 @ 84,860: 22x15
#155 @ 581,77: 29x22
#156 @ 175,769: 25x10
#157 @ 204,635: 24x24
#158 @ 959,204: 16x10
#159 @ 19,846: 24x20
#160 @ 479,583: 15x27
#161 @ 769,377: 16x24
#162 @ 954,670: 16x27
#163 @ 857,392: 12x3
#164 @ 627,391: 24x14
#165 @ 506,871: 11x16
#166 @ 169,876: 12x13
#167 @ 842,717: 12x13
#168 @ 964,191: 23x14
#169 @ 201,910: 18x29
#170 @ 332,712: 10x14
#171 @ 533,262: 27x23
#172 @ 413,884: 10x29
#173 @ 707,356: 25x29
#174 @ 617,351: 10x27
#175 @ 914,173: 12x25
#176 @ 60,314: 19x10
#177 @ 534,872: 21x19
#178 @ 527,423: 19x19
#179 @ 232,245: 13x23
#180 @ 983,953: 13x20
#181 @ 781,377: 17x26
#182 @ 387,935: 19x22
#183 @ 173,335: 20x10
#184 @ 690,365: 13x23
#185 @ 514,384: 7x7
#186 @ 115,382: 28x28
#187 @ 435,889: 28x25
#188 @ 345,489: 24x13
#189 @ 200,777: 25x29
#190 @ 126,342: 18x21
#191 @ 653,333: 13x12
#192 @ 578,953: 16x16
#193 @ 529,763: 16x22
#194 @ 244,393: 11x11
#195 @ 963,678: 13x12
#196 @ 916,592: 20x10
#197 @ 480,702: 23x17
#198 @ 851,952: 19x16
#199 @ 163,762: 25x15
#200 @ 823,209: 22x22
#201 @ 600,634: 27x20
#202 @ 231,241: 10x24
#203 @ 835,195: 14x18
#204 @ 707,670: 11x19
#205 @ 325,85: 15x21
#206 @ 3,930: 25x26
#207 @ 394,623: 28x16
#208 @ 402,471: 13x7
#209 @ 551,979: 27x14
#210 @ 670,233: 11x16
#211 @ 916,158: 11x26
#212 @ 668,615: 13x13
#213 @ 729,952: 17x16
#214 @ 553,103: 17x11
#215 @ 518,422: 26x15
#216 @ 494,236: 24x25
#217 @ 461,53: 20x27
#218 @ 574,242: 5x5
#219 @ 13,458: 10x16
#220 @ 157,649: 27x13
#221 @ 288,440: 15x19
#222 @ 167,374: 24x20
#223 @ 120,158: 12x28
#224 @ 807,188: 25x14
#225 @ 725,955: 10x23
#226 @ 319,321: 17x29
#227 @ 867,64: 26x15
#228 @ 198,899: 11x10
#229 @ 411,610: 14x17
#230 @ 29,222: 19x15
#231 @ 73,12: 14x28
#232 @ 986,813: 10x24
#233 @ 80,634: 27x24
#234 @ 709,45: 21x28
#235 @ 673,354: 29x12
#236 @ 247,299: 12x20
#237 @ 713,913: 23x18
#238 @ 587,28: 24x25
#239 @ 548,845: 13x28
#240 @ 386,2: 27x13
#241 @ 421,173: 10x17
#242 @ 336,645: 14x14
#243 @ 723,786: 27x28
#244 @ 536,401: 23x27
#245 @ 801,55: 22x25
#246 @ 38,917: 15x15
#247 @ 81,738: 15x20
#248 @ 594,343: 29x16
#249 @ 348,961: 21x21
#250 @ 512,782: 14x21
#251 @ 915,463: 12x22
#252 @ 41,259: 15x16
#253 @ 290,550: 12x28
#254 @ 130,186: 26x27
#255 @ 437,179: 23x24
#256 @ 127,190: 12x29
#257 @ 267,659: 15x11
#258 @ 922,494: 12x20
#259 @ 459,871: 15x21
#260 @ 286,911: 11x20
#261 @ 172,497: 10x14
#262 @ 26,145: 19x17
#263 @ 115,788: 12x13
#264 @ 696,390: 10x25
#265 @ 927,445: 26x17
#266 @ 686,301: 20x15
#267 @ 453,248: 22x18
#268 @ 675,953: 22x28
#269 @ 34,463: 27x18
#270 @ 763,500: 16x16
#271 @ 393,691: 19x26
#272 @ 157,212: 20x22
#273 @ 576,701: 20x16
#274 @ 11,795: 29x29
#275 @ 977,425: 11x27
#276 @ 93,949: 10x11
#277 @ 621,379: 21x11
#278 @ 238,308: 25x20
#279 @ 329,914: 10x14
#280 @ 423,467: 14x23
#281 @ 896,166: 20x17
#282 @ 175,32: 20x28
#283 @ 88,852: 19x18
#284 @ 441,814: 26x13
#285 @ 476,815: 20x24
#286 @ 797,49: 22x18
#287 @ 193,460: 20x18
#288 @ 541,352: 19x10
#289 @ 966,373: 11x14
#290 @ 10,60: 17x22
#291 @ 855,443: 20x22
#292 @ 58,494: 11x23
#293 @ 965,357: 20x23
#294 @ 453,686: 15x15
#295 @ 389,740: 10x27
#296 @ 928,371: 29x20
#297 @ 635,752: 27x25
#298 @ 941,508: 29x22
#299 @ 639,104: 26x23
#300 @ 626,701: 29x19
#301 @ 504,535: 24x26
#302 @ 83,843: 15x27
#303 @ 867,972: 28x12
#304 @ 617,372: 29x15
#305 @ 198,29: 22x22
#306 @ 71,811: 13x22
#307 @ 613,277: 19x16
#308 @ 521,875: 17x26
#309 @ 249,439: 10x15
#310 @ 177,750: 21x23
#311 @ 899,412: 15x14
#312 @ 587,410: 28x29
#313 @ 609,22: 26x15
#314 @ 180,744: 23x14
#315 @ 869,432: 18x19
#316 @ 497,460: 26x29
#317 @ 384,575: 12x14
#318 @ 730,796: 13x21
#319 @ 900,292: 21x28
#320 @ 553,451: 13x29
#321 @ 8,456: 13x18
#322 @ 42,312: 12x14
#323 @ 231,798: 25x26
#324 @ 567,55: 29x23
#325 @ 254,646: 13x21
#326 @ 652,103: 24x23
#327 @ 60,719: 11x27
#328 @ 692,915: 29x22
#329 @ 75,485: 16x19
#330 @ 802,114: 27x19
#331 @ 802,255: 25x22
#332 @ 976,684: 12x20
#333 @ 6,934: 18x24
#334 @ 520,297: 21x22
#335 @ 311,641: 13x13
#336 @ 535,759: 23x22
#337 @ 667,248: 13x18
#338 @ 768,603: 16x26
#339 @ 116,759: 27x17
#340 @ 658,63: 24x16
#341 @ 920,120: 22x27
#342 @ 829,201: 25x20
#343 @ 145,53: 20x12
#344 @ 954,669: 21x10
#345 @ 644,238: 24x18
#346 @ 161,395: 26x16
#347 @ 569,207: 15x20
#348 @ 368,786: 12x14
#349 @ 564,634: 12x21
#350 @ 374,474: 20x22
#351 @ 422,879: 28x11
#352 @ 265,844: 13x29
#353 @ 827,412: 21x15
#354 @ 826,105: 14x13
#355 @ 163,262: 13x12
#356 @ 506,37: 10x14
#357 @ 539,905: 16x12
#358 @ 169,610: 21x17
#359 @ 764,369: 12x23
#360 @ 31,975: 11x25
#361 @ 826,184: 29x13
#362 @ 881,951: 14x18
#363 @ 237,775: 12x12
#364 @ 70,393: 17x11
#365 @ 585,150: 12x17
#366 @ 68,921: 26x29
#367 @ 389,138: 10x23
#368 @ 351,784: 24x23
#369 @ 395,968: 27x12
#370 @ 68,261: 11x19
#371 @ 702,953: 16x16
#372 @ 167,253: 17x25
#373 @ 873,976: 14x18
#374 @ 715,953: 11x29
#375 @ 669,363: 24x18
#376 @ 390,677: 28x18
#377 @ 839,134: 18x13
#378 @ 357,923: 26x10
#379 @ 526,400: 18x17
#380 @ 230,71: 18x29
#381 @ 162,420: 19x20
#382 @ 37,888: 18x20
#383 @ 965,435: 13x25
#384 @ 336,284: 14x26
#385 @ 956,814: 10x26
#386 @ 577,970: 14x13
#387 @ 762,141: 22x19
#388 @ 182,31: 19x19
#389 @ 307,323: 12x26
#390 @ 957,612: 24x18
#391 @ 513,872: 18x27
#392 @ 916,378: 15x19
#393 @ 927,343: 27x16
#394 @ 897,197: 24x12
#395 @ 224,929: 24x20
#396 @ 13,664: 12x14
#397 @ 570,227: 14x26
#398 @ 99,323: 18x12
#399 @ 129,508: 20x12
#400 @ 302,832: 26x10
#401 @ 274,940: 19x29
#402 @ 230,803: 11x23
#403 @ 148,592: 22x14
#404 @ 11,138: 20x10
#405 @ 732,923: 11x22
#406 @ 929,115: 16x27
#407 @ 189,438: 22x28
#408 @ 551,165: 26x19
#409 @ 685,962: 15x13
#410 @ 310,571: 15x27
#411 @ 356,643: 16x25
#412 @ 813,260: 17x16
#413 @ 909,457: 16x16
#414 @ 359,801: 12x17
#415 @ 715,347: 15x21
#416 @ 252,541: 24x26
#417 @ 807,416: 23x14
#418 @ 737,501: 28x13
#419 @ 175,631: 18x23
#420 @ 131,921: 27x24
#421 @ 971,185: 24x16
#422 @ 354,859: 16x20
#423 @ 78,549: 29x24
#424 @ 799,657: 23x21
#425 @ 181,152: 22x18
#426 @ 223,297: 22x14
#427 @ 970,833: 11x16
#428 @ 794,138: 18x19
#429 @ 396,367: 25x11
#430 @ 639,158: 13x27
#431 @ 558,697: 18x22
#432 @ 190,868: 18x17
#433 @ 957,5: 12x29
#434 @ 397,180: 29x14
#435 @ 777,665: 15x17
#436 @ 949,138: 24x10
#437 @ 554,848: 3x13
#438 @ 619,629: 24x17
#439 @ 336,85: 21x14
#440 @ 141,933: 26x24
#441 @ 15,940: 4x9
#442 @ 660,334: 21x16
#443 @ 516,400: 13x18
#444 @ 236,785: 14x26
#445 @ 408,431: 14x23
#446 @ 340,597: 27x27
#447 @ 493,318: 29x11
#448 @ 690,824: 10x19
#449 @ 105,51: 29x11
#450 @ 439,777: 27x27
#451 @ 484,773: 26x28
#452 @ 529,432: 24x13
#453 @ 211,460: 20x20
#454 @ 129,362: 15x28
#455 @ 940,352: 20x12
#456 @ 875,596: 14x24
#457 @ 877,243: 11x17
#458 @ 2,378: 20x24
#459 @ 364,598: 24x22
#460 @ 937,532: 13x22
#461 @ 936,822: 15x15
#462 @ 913,355: 15x11
#463 @ 661,170: 12x14
#464 @ 725,791: 22x13
#465 @ 672,143: 22x18
#466 @ 487,873: 21x21
#467 @ 286,276: 28x11
#468 @ 690,972: 11x24
#469 @ 123,209: 20x16
#470 @ 671,208: 29x13
#471 @ 286,191: 22x21
#472 @ 842,812: 26x10
#473 @ 245,576: 22x28
#474 @ 486,258: 27x29
#475 @ 658,152: 28x26
#476 @ 0,444: 22x14
#477 @ 341,236: 28x29
#478 @ 458,163: 28x28
#479 @ 495,458: 20x17
#480 @ 89,824: 25x19
#481 @ 549,618: 21x21
#482 @ 322,705: 29x10
#483 @ 909,522: 19x27
#484 @ 435,679: 22x13
#485 @ 492,963: 29x28
#486 @ 272,263: 15x19
#487 @ 381,613: 27x20
#488 @ 909,540: 16x26
#489 @ 620,429: 24x12
#490 @ 610,339: 28x10
#491 @ 861,444: 10x21
#492 @ 299,441: 20x15
#493 @ 593,334: 17x12
#494 @ 428,613: 18x12
#495 @ 106,486: 12x7
#496 @ 951,211: 22x27
#497 @ 641,250: 17x24
#498 @ 487,574: 12x23
#499 @ 658,164: 17x10
#500 @ 917,322: 13x15
#501 @ 149,764: 20x26
#502 @ 874,965: 11x27
#503 @ 228,357: 11x26
#504 @ 791,120: 22x20
#505 @ 681,594: 12x13
#506 @ 934,928: 23x25
#507 @ 34,426: 12x23
#508 @ 647,157: 20x16
#509 @ 950,939: 19x12
#510 @ 257,278: 17x24
#511 @ 379,920: 27x16
#512 @ 142,649: 20x23
#513 @ 445,276: 16x20
#514 @ 652,459: 27x14
#515 @ 886,163: 19x24
#516 @ 244,374: 17x22
#517 @ 776,484: 14x23
#518 @ 414,664: 12x29
#519 @ 547,248: 22x18
#520 @ 640,148: 18x13
#521 @ 769,142: 21x10
#522 @ 354,205: 26x20
#523 @ 616,496: 12x26
#524 @ 876,86: 15x18
#525 @ 187,53: 15x19
#526 @ 423,757: 17x21
#527 @ 749,748: 27x23
#528 @ 44,735: 18x26
#529 @ 221,407: 26x25
#530 @ 287,304: 23x18
#531 @ 64,95: 16x24
#532 @ 888,370: 16x25
#533 @ 97,773: 24x18
#534 @ 398,468: 22x16
#535 @ 909,261: 17x17
#536 @ 212,602: 12x22
#537 @ 759,413: 28x15
#538 @ 280,310: 28x23
#539 @ 548,782: 13x23
#540 @ 303,547: 29x28
#541 @ 542,886: 25x15
#542 @ 656,136: 16x14
#543 @ 394,345: 13x12
#544 @ 677,99: 29x16
#545 @ 581,616: 14x25
#546 @ 350,517: 25x18
#547 @ 922,211: 19x13
#548 @ 219,767: 23x13
#549 @ 84,970: 19x18
#550 @ 223,349: 22x16
#551 @ 400,591: 21x27
#552 @ 324,898: 24x22
#553 @ 380,83: 24x10
#554 @ 676,240: 13x19
#555 @ 881,905: 26x23
#556 @ 667,96: 10x14
#557 @ 709,323: 10x14
#558 @ 65,561: 20x21
#559 @ 334,497: 12x28
#560 @ 39,468: 15x17
#561 @ 315,675: 10x10
#562 @ 876,595: 25x18
#563 @ 59,982: 21x15
#564 @ 634,821: 12x12
#565 @ 935,438: 10x24
#566 @ 144,191: 21x27
#567 @ 648,612: 24x13
#568 @ 648,170: 22x28
#569 @ 484,302: 21x18
#570 @ 927,137: 11x25
#571 @ 327,512: 14x23
#572 @ 125,752: 16x16
#573 @ 648,147: 24x14
#574 @ 805,287: 15x18
#575 @ 450,235: 16x16
#576 @ 284,257: 22x21
#577 @ 492,835: 27x16
#578 @ 213,221: 28x25
#579 @ 825,417: 17x27
#580 @ 860,534: 24x23
#581 @ 486,714: 14x14
#582 @ 273,907: 19x26
#583 @ 844,194: 12x15
#584 @ 736,491: 29x21
#585 @ 706,929: 25x13
#586 @ 348,780: 8x17
#587 @ 388,491: 12x12
#588 @ 559,270: 15x14
#589 @ 580,7: 26x22
#590 @ 764,501: 16x21
#591 @ 852,663: 17x16
#592 @ 172,554: 14x25
#593 @ 652,707: 10x11
#594 @ 740,897: 27x11
#595 @ 212,772: 28x15
#596 @ 546,625: 13x20
#597 @ 313,683: 23x20
#598 @ 101,432: 18x14
#599 @ 256,773: 29x27
#600 @ 347,761: 15x14
#601 @ 483,567: 28x17
#602 @ 538,581: 21x14
#603 @ 749,48: 19x22
#604 @ 88,309: 16x20
#605 @ 781,292: 24x23
#606 @ 630,345: 28x21
#607 @ 848,948: 25x15
#608 @ 35,921: 20x17
#609 @ 190,343: 12x21
#610 @ 798,539: 11x19
#611 @ 747,422: 29x27
#612 @ 355,956: 20x10
#613 @ 468,167: 20x28
#614 @ 663,264: 18x20
#615 @ 257,785: 18x22
#616 @ 163,503: 22x29
#617 @ 390,500: 21x19
#618 @ 60,254: 21x17
#619 @ 352,400: 21x25
#620 @ 83,921: 15x26
#621 @ 135,275: 18x23
#622 @ 131,331: 17x27
#623 @ 16,191: 26x21
#624 @ 949,871: 11x20
#625 @ 445,182: 26x12
#626 @ 5,451: 19x17
#627 @ 760,64: 19x18
#628 @ 443,3: 11x14
#629 @ 610,355: 28x14
#630 @ 38,686: 11x29
#631 @ 948,338: 12x12
#632 @ 321,505: 19x21
#633 @ 854,390: 21x16
#634 @ 202,43: 25x15
#635 @ 63,303: 26x22
#636 @ 520,866: 15x15
#637 @ 68,8: 20x28
#638 @ 821,784: 15x21
#639 @ 305,656: 14x29
#640 @ 170,403: 29x25
#641 @ 383,739: 4x9
#642 @ 692,327: 28x23
#643 @ 676,258: 15x25
#644 @ 457,175: 27x11
#645 @ 706,898: 25x21
#646 @ 950,456: 22x24
#647 @ 364,207: 12x15
#648 @ 238,39: 26x28
#649 @ 117,772: 18x15
#650 @ 746,413: 27x20
#651 @ 182,28: 17x15
#652 @ 182,160: 15x10
#653 @ 592,148: 27x20
#654 @ 206,601: 16x24
#655 @ 556,134: 12x16
#656 @ 528,307: 21x24
#657 @ 262,190: 29x14
#658 @ 945,218: 26x16
#659 @ 57,339: 27x11
#660 @ 242,586: 14x11
#661 @ 174,900: 28x17
#662 @ 973,695: 14x21
#663 @ 430,402: 21x27
#664 @ 882,627: 14x12
#665 @ 374,714: 28x26
#666 @ 211,871: 10x19
#667 @ 259,941: 10x22
#668 @ 84,648: 7x5
#669 @ 60,869: 29x13
#670 @ 443,819: 28x20
#671 @ 103,513: 15x24
#672 @ 57,795: 16x17
#673 @ 55,893: 28x13
#674 @ 400,466: 28x23
#675 @ 359,314: 25x13
#676 @ 388,518: 16x27
#677 @ 964,662: 14x16
#678 @ 421,55: 23x23
#679 @ 355,774: 16x13
#680 @ 72,351: 27x28
#681 @ 78,168: 10x12
#682 @ 514,422: 18x23
#683 @ 93,267: 10x11
#684 @ 160,352: 19x17
#685 @ 968,442: 3x14
#686 @ 313,587: 10x18
#687 @ 737,340: 13x27
#688 @ 944,828: 29x23
#689 @ 26,707: 19x25
#690 @ 774,375: 22x26
#691 @ 428,817: 21x16
#692 @ 522,755: 26x27
#693 @ 419,382: 14x19
#694 @ 507,445: 20x14
#695 @ 490,324: 20x20
#696 @ 83,643: 27x25
#697 @ 231,90: 29x22
#698 @ 802,675: 10x14
#699 @ 192,552: 15x12
#700 @ 310,346: 16x18
#701 @ 902,444: 26x21
#702 @ 760,712: 12x26
#703 @ 772,68: 15x16
#704 @ 341,343: 26x12
#705 @ 635,795: 12x26
#706 @ 754,426: 19x24
#707 @ 675,762: 10x26
#708 @ 392,335: 22x18
#709 @ 694,197: 28x29
#710 @ 433,628: 18x15
#711 @ 51,258: 20x17
#712 @ 640,458: 24x14
#713 @ 221,982: 10x16
#714 @ 409,863: 21x20
#715 @ 186,749: 24x21
#716 @ 869,759: 23x14
#717 @ 950,24: 27x25
#718 @ 30,516: 12x13
#719 @ 729,536: 26x28
#720 @ 927,404: 14x29
#721 @ 763,303: 27x20
#722 @ 283,563: 27x14
#723 @ 720,542: 13x21
#724 @ 100,939: 23x25
#725 @ 216,447: 29x29
#726 @ 347,204: 26x19
#727 @ 156,272: 21x16
#728 @ 756,666: 20x11
#729 @ 538,584: 10x16
#730 @ 698,395: 19x17
#731 @ 356,34: 17x24
#732 @ 558,418: 29x10
#733 @ 855,61: 25x26
#734 @ 379,247: 17x9
#735 @ 393,352: 25x18
#736 @ 426,759: 8x16
#737 @ 588,511: 15x28
#738 @ 803,205: 12x25
#739 @ 264,387: 11x23
#740 @ 172,292: 28x20
#741 @ 623,647: 28x16
#742 @ 109,916: 10x28
#743 @ 139,807: 15x17
#744 @ 854,284: 21x20
#745 @ 919,251: 25x22
#746 @ 162,838: 25x10
#747 @ 47,977: 15x16
#748 @ 82,526: 11x29
#749 @ 483,919: 25x17
#750 @ 259,929: 13x18
#751 @ 637,964: 15x29
#752 @ 227,697: 12x25
#753 @ 869,592: 17x12
#754 @ 151,425: 11x10
#755 @ 393,886: 24x11
#756 @ 143,434: 29x18
#757 @ 647,115: 11x16
#758 @ 919,707: 10x29
#759 @ 390,308: 12x25
#760 @ 832,197: 17x29
#761 @ 495,442: 25x24
#762 @ 796,32: 25x21
#763 @ 530,817: 25x17
#764 @ 909,574: 24x14
#765 @ 20,939: 11x10
#766 @ 192,928: 14x13
#767 @ 28,395: 23x17
#768 @ 724,627: 17x14
#769 @ 447,931: 16x16
#770 @ 649,965: 11x21
#771 @ 700,939: 22x18
#772 @ 296,772: 15x20
#773 @ 237,600: 28x20
#774 @ 675,48: 28x22
#775 @ 218,570: 12x27
#776 @ 467,318: 25x15
#777 @ 358,873: 25x20
#778 @ 142,505: 16x24
#779 @ 25,184: 17x26
#780 @ 487,980: 16x14
#781 @ 492,962: 15x21
#782 @ 907,567: 15x27
#783 @ 135,318: 17x18
#784 @ 220,879: 10x13
#785 @ 689,210: 14x11
#786 @ 133,381: 16x25
#787 @ 166,624: 22x27
#788 @ 187,162: 10x11
#789 @ 139,522: 10x19
#790 @ 559,131: 18x17
#791 @ 484,554: 29x24
#792 @ 359,417: 10x24
#793 @ 634,807: 10x15
#794 @ 485,29: 24x16
#795 @ 877,59: 11x29
#796 @ 754,758: 19x20
#797 @ 77,877: 20x14
#798 @ 918,42: 16x21
#799 @ 621,381: 12x16
#800 @ 400,603: 29x26
#801 @ 49,665: 10x14
#802 @ 623,123: 29x19
#803 @ 659,963: 13x13
#804 @ 384,930: 23x13
#805 @ 45,892: 4x12
#806 @ 118,444: 26x15
#807 @ 163,498: 24x19
#808 @ 677,83: 20x21
#809 @ 6,606: 16x16
#810 @ 466,604: 28x25
#811 @ 361,890: 10x27
#812 @ 138,388: 7x13
#813 @ 217,578: 15x19
#814 @ 105,207: 26x13
#815 @ 369,491: 26x26
#816 @ 946,287: 20x22
#817 @ 282,448: 20x23
#818 @ 214,38: 29x20
#819 @ 544,467: 16x13
#820 @ 423,366: 28x11
#821 @ 862,256: 26x13
#822 @ 606,18: 27x16
#823 @ 244,260: 16x29
#824 @ 930,807: 28x19
#825 @ 966,413: 10x26
#826 @ 558,201: 29x15
#827 @ 390,916: 11x21
#828 @ 773,899: 25x23
#829 @ 479,274: 14x23
#830 @ 387,162: 14x4
#831 @ 448,751: 20x16
#832 @ 532,17: 10x20
#833 @ 329,971: 20x15
#834 @ 379,495: 10x26
#835 @ 867,967: 21x14
#836 @ 623,266: 17x21
#837 @ 814,542: 22x24
#838 @ 113,769: 28x13
#839 @ 18,210: 12x18
#840 @ 706,855: 24x28
#841 @ 43,412: 17x20
#842 @ 594,144: 20x16
#843 @ 918,491: 15x14
#844 @ 570,810: 14x26
#845 @ 956,743: 22x18
#846 @ 432,907: 17x21
#847 @ 593,699: 21x18
#848 @ 108,908: 22x14
#849 @ 250,394: 11x24
#850 @ 783,511: 18x13
#851 @ 879,273: 10x11
#852 @ 933,453: 11x26
#853 @ 803,865: 13x26
#854 @ 359,841: 10x14
#855 @ 744,662: 23x10
#856 @ 260,413: 14x10
#857 @ 857,954: 11x23
#858 @ 434,780: 23x27
#859 @ 968,701: 10x21
#860 @ 615,507: 10x28
#861 @ 716,935: 27x18
#862 @ 385,576: 14x10
#863 @ 737,340: 12x11
#864 @ 453,864: 22x13
#865 @ 439,8: 24x11
#866 @ 694,353: 16x20
#867 @ 223,200: 12x29
#868 @ 409,44: 23x22
#869 @ 654,72: 23x13
#870 @ 560,167: 18x12
#871 @ 755,520: 14x15
#872 @ 906,62: 16x10
#873 @ 162,911: 24x29
#874 @ 88,265: 19x16
#875 @ 670,69: 12x24
#876 @ 954,527: 20x11
#877 @ 704,526: 10x17
#878 @ 343,972: 24x22
#879 @ 153,427: 6x5
#880 @ 228,793: 22x25
#881 @ 713,381: 15x22
#882 @ 502,170: 17x11
#883 @ 175,259: 29x28
#884 @ 133,809: 24x27
#885 @ 466,300: 19x27
#886 @ 516,429: 7x9
#887 @ 737,787: 19x27
#888 @ 767,345: 18x28
#889 @ 696,826: 15x26
#890 @ 248,416: 20x28
#891 @ 85,166: 14x11
#892 @ 794,882: 21x27
#893 @ 429,908: 20x15
#894 @ 742,902: 12x25
#895 @ 341,782: 26x14
#896 @ 940,777: 16x10
#897 @ 850,341: 26x17
#898 @ 557,791: 17x28
#899 @ 277,657: 19x15
#900 @ 774,326: 27x24
#901 @ 853,655: 20x22
#902 @ 180,923: 15x13
#903 @ 318,808: 18x14
#904 @ 212,90: 24x18
#905 @ 595,278: 23x20
#906 @ 150,57: 19x22
#907 @ 967,366: 10x8
#908 @ 625,789: 18x25
#909 @ 404,508: 12x22
#910 @ 330,484: 28x28
#911 @ 70,736: 15x13
#912 @ 521,791: 25x28
#913 @ 90,824: 15x17
#914 @ 780,342: 27x28
#915 @ 14,944: 21x20
#916 @ 510,927: 29x23
#917 @ 385,159: 28x11
#918 @ 68,204: 26x13
#919 @ 460,933: 11x10
#920 @ 437,860: 20x18
#921 @ 642,95: 10x19
#922 @ 828,719: 22x20
#923 @ 373,366: 13x16
#924 @ 209,889: 14x22
#925 @ 544,914: 22x29
#926 @ 536,416: 23x12
#927 @ 930,215: 17x16
#928 @ 644,98: 5x12
#929 @ 365,374: 28x18
#930 @ 961,363: 22x15
#931 @ 647,728: 17x18
#932 @ 883,499: 11x17
#933 @ 751,904: 28x28
#934 @ 285,267: 13x14
#935 @ 587,664: 27x11
#936 @ 43,106: 28x10
#937 @ 218,352: 28x21
#938 @ 724,64: 11x25
#939 @ 206,461: 11x15
#940 @ 101,45: 10x14
#941 @ 154,585: 21x17
#942 @ 715,435: 29x14
#943 @ 861,527: 17x27
#944 @ 418,351: 22x20
#945 @ 517,166: 26x16
#946 @ 748,492: 24x29
#947 @ 473,760: 11x13
#948 @ 854,590: 24x23
#949 @ 349,211: 22x14
#950 @ 26,350: 25x16
#951 @ 364,31: 28x25
#952 @ 496,218: 15x18
#953 @ 760,386: 11x19
#954 @ 79,899: 28x29
#955 @ 529,9: 10x22
#956 @ 746,581: 24x21
#957 @ 710,978: 19x11
#958 @ 518,744: 11x25
#959 @ 656,702: 17x10
#960 @ 554,122: 10x25
#961 @ 55,667: 29x11
#962 @ 162,755: 20x21
#963 @ 668,822: 11x19
#964 @ 231,420: 26x17
#965 @ 572,710: 21x26
#966 @ 267,87: 15x21
#967 @ 354,601: 18x22
#968 @ 377,737: 25x21
#969 @ 707,344: 21x28
#970 @ 710,403: 21x14
#971 @ 116,782: 28x12
#972 @ 184,437: 25x29
#973 @ 427,633: 25x15
#974 @ 380,662: 21x14
#975 @ 742,523: 18x22
#976 @ 335,678: 26x17
#977 @ 919,550: 22x19
#978 @ 128,38: 25x14
#979 @ 392,163: 26x13
#980 @ 631,644: 20x15
#981 @ 117,517: 28x18
#982 @ 861,159: 27x17
#983 @ 504,210: 18x23
#984 @ 11,401: 29x16
#985 @ 611,349: 24x12
#986 @ 446,62: 16x25
#987 @ 408,332: 15x24
#988 @ 813,147: 14x24
#989 @ 297,267: 13x11
#990 @ 150,893: 10x29
#991 @ 453,798: 21x29
#992 @ 563,33: 21x18
#993 @ 717,652: 21x29
#994 @ 719,166: 14x16
#995 @ 887,378: 15x20
#996 @ 393,481: 16x29
#997 @ 581,516: 20x28
#998 @ 376,245: 25x14
#999 @ 297,418: 24x29
#1000 @ 41,388: 15x13
#1001 @ 233,380: 20x14
#1002 @ 644,430: 13x13
#1003 @ 480,88: 16x14
#1004 @ 552,29: 21x11
#1005 @ 929,571: 13x29
#1006 @ 736,881: 28x18
#1007 @ 798,407: 20x20
#1008 @ 149,813: 21x10
#1009 @ 545,166: 22x11
#1010 @ 437,599: 15x22
#1011 @ 736,578: 17x23
#1012 @ 972,173: 11x19
#1013 @ 694,701: 10x29
#1014 @ 399,532: 22x26
#1015 @ 716,588: 27x29
#1016 @ 571,276: 10x19
#1017 @ 371,748: 22x14
#1018 @ 349,957: 27x17
#1019 @ 644,917: 18x17
#1020 @ 863,292: 28x22
#1021 @ 134,484: 14x28
#1022 @ 337,584: 14x19
#1023 @ 729,881: 14x26
#1024 @ 515,349: 27x17
#1025 @ 320,476: 19x14
#1026 @ 911,576: 19x6
#1027 @ 650,439: 17x15
#1028 @ 690,684: 27x27
#1029 @ 349,346: 12x5
#1030 @ 945,759: 11x26
#1031 @ 427,829: 16x15
#1032 @ 225,277: 25x14
#1033 @ 287,300: 15x25
#1034 @ 130,357: 27x18
#1035 @ 927,910: 27x28
#1036 @ 807,785: 22x11
#1037 @ 389,568: 27x25
#1038 @ 563,120: 16x19
#1039 @ 755,505: 10x10
#1040 @ 81,646: 24x11
#1041 @ 609,625: 19x28
#1042 @ 886,286: 17x19
#1043 @ 434,177: 20x24
#1044 @ 938,220: 24x23
#1045 @ 596,898: 10x13
#1046 @ 711,319: 18x10
#1047 @ 732,258: 19x13
#1048 @ 327,804: 11x21
#1049 @ 415,77: 13x29
#1050 @ 456,26: 15x23
#1051 @ 556,612: 17x26
#1052 @ 52,339: 29x14
#1053 @ 492,745: 27x24
#1054 @ 681,414: 22x19
#1055 @ 683,603: 10x29
#1056 @ 96,959: 12x16
#1057 @ 570,664: 21x12
#1058 @ 555,742: 16x22
#1059 @ 145,182: 12x10
#1060 @ 555,555: 13x26
#1061 @ 794,201: 27x27
#1062 @ 565,945: 18x20
#1063 @ 294,531: 19x29
#1064 @ 765,574: 14x19
#1065 @ 160,897: 16x12
#1066 @ 427,776: 13x24
#1067 @ 294,838: 14x16
#1068 @ 935,895: 13x28
#1069 @ 962,830: 16x17
#1070 @ 454,238: 20x14
#1071 @ 811,290: 20x28
#1072 @ 634,619: 20x11
#1073 @ 677,184: 29x26
#1074 @ 568,98: 22x22
#1075 @ 366,10: 24x16
#1076 @ 353,588: 16x28
#1077 @ 572,693: 18x26
#1078 @ 101,40: 21x16
#1079 @ 450,226: 13x16
#1080 @ 470,480: 19x27
#1081 @ 925,274: 14x28
#1082 @ 551,436: 17x14
#1083 @ 792,510: 18x23
#1084 @ 929,548: 12x10
#1085 @ 333,780: 18x18
#1086 @ 886,111: 24x26
#1087 @ 539,576: 23x12
#1088 @ 259,852: 23x17
#1089 @ 233,84: 18x18
#1090 @ 75,563: 12x19
#1091 @ 329,55: 16x15
#1092 @ 826,975: 13x11
#1093 @ 36,828: 20x24
#1094 @ 725,740: 18x24
#1095 @ 371,861: 25x22
#1096 @ 399,624: 11x25
#1097 @ 240,303: 15x28
#1098 @ 831,711: 21x23
#1099 @ 720,258: 14x21
#1100 @ 510,377: 19x25
#1101 @ 578,11: 22x20
#1102 @ 347,590: 25x13
#1103 @ 321,927: 14x17
#1104 @ 481,742: 29x26
#1105 @ 959,179: 17x26
#1106 @ 127,758: 25x21
#1107 @ 950,404: 28x17
#1108 @ 827,282: 16x28
#1109 @ 716,884: 22x28
#1110 @ 16,351: 29x18
#1111 @ 384,571: 28x29
#1112 @ 801,211: 29x11
#1113 @ 203,594: 23x12
#1114 @ 47,482: 14x12
#1115 @ 543,104: 28x27
#1116 @ 391,127: 27x22
#1117 @ 236,954: 12x18
#1118 @ 550,613: 17x25
#1119 @ 10,509: 21x11
#1120 @ 347,828: 19x29
#1121 @ 933,322: 23x26
#1122 @ 915,735: 24x18
#1123 @ 859,615: 28x15
#1124 @ 808,655: 17x26
#1125 @ 441,869: 17x12
#1126 @ 301,189: 11x22
#1127 @ 763,68: 26x27
#1128 @ 1,568: 26x13
#1129 @ 635,114: 14x27
#1130 @ 278,641: 27x24
#1131 @ 84,470: 28x19
#1132 @ 65,618: 19x22
#1133 @ 150,468: 26x25
#1134 @ 367,142: 29x25
#1135 @ 447,80: 27x22
#1136 @ 159,101: 11x17
#1137 @ 345,777: 15x24
#1138 @ 344,654: 20x24
#1139 @ 636,72: 29x17
#1140 @ 44,299: 25x23
#1141 @ 360,787: 25x15
#1142 @ 642,768: 24x20
#1143 @ 810,734: 10x25
#1144 @ 594,328: 18x29
#1145 @ 228,40: 26x29
#1146 @ 781,430: 20x23
#1147 @ 537,297: 26x16
#1148 @ 757,399: 16x17
#1149 @ 567,270: 16x23
#1150 @ 837,821: 12x11
#1151 @ 343,573: 16x26
#1152 @ 964,204: 20x20
#1153 @ 902,154: 17x19
#1154 @ 484,460: 28x29
#1155 @ 815,872: 18x25
#1156 @ 198,936: 10x11
#1157 @ 390,686: 20x16
#1158 @ 255,406: 17x27
#1159 @ 665,62: 17x21
#1160 @ 840,825: 16x24
#1161 @ 704,407: 24x12
#1162 @ 507,524: 14x28
#1163 @ 521,425: 14x6
#1164 @ 435,783: 18x18
#1165 @ 171,841: 21x13
#1166 @ 7,278: 14x22
#1167 @ 946,881: 13x24
#1168 @ 900,415: 22x28
#1169 @ 635,184: 22x29
#1170 @ 348,249: 16x13
#1171 @ 840,460: 25x17
#1172 @ 262,858: 16x12
#1173 @ 248,625: 20x24
#1174 @ 424,400: 29x22
#1175 @ 539,406: 25x17
#1176 @ 376,733: 15x28
#1177 @ 456,754: 7x5
#1178 @ 876,602: 10x20
#1179 @ 88,486: 21x28
#1180 @ 291,650: 24x13
#1181 @ 86,953: 12x26
#1182 @ 646,251: 18x17
#1183 @ 503,322: 16x14
#1184 @ 819,973: 28x16
#1185 @ 434,587: 15x20
#1186 @ 125,209: 20x20
#1187 @ 493,988: 10x10
#1188 @ 804,750: 14x25
#1189 @ 26,315: 18x12
#1190 @ 457,909: 27x19
#1191 @ 126,487: 28x25
#1192 @ 234,603: 10x29
#1193 @ 386,617: 29x23
#1194 @ 753,61: 13x26
#1195 @ 956,521: 27x28
#1196 @ 442,823: 10x20
#1197 @ 501,514: 27x17
#1198 @ 727,974: 17x14
#1199 @ 533,298: 23x12
#1200 @ 295,555: 24x22
#1201 @ 525,801: 14x26
#1202 @ 232,60: 10x15
#1203 @ 74,971: 22x27
#1204 @ 31,208: 12x22
#1205 @ 118,45: 22x16
#1206 @ 799,342: 28x23
#1207 @ 786,881: 20x21
#1208 @ 588,199: 11x29
#1209 @ 904,53: 21x19
#1210 @ 638,933: 16x19
#1211 @ 771,478: 13x23
#1212 @ 503,231: 20x20
#1213 @ 351,161: 18x20
#1214 @ 535,574: 24x10
#1215 @ 679,780: 17x12
#1216 @ 106,425: 26x20
#1217 @ 937,206: 20x19
#1218 @ 706,865: 15x21
#1219 @ 480,568: 13x22
#1220 @ 397,945: 20x26
#1221 @ 836,64: 15x19
#1222 @ 119,504: 28x16
#1223 @ 63,761: 16x14
#1224 @ 247,99: 27x20
#1225 @ 920,118: 21x18
#1226 @ 451,42: 29x27
#1227 @ 69,143: 28x14
#1228 @ 197,411: 16x23
#1229 @ 832,138: 13x11
#1230 @ 195,593: 23x16
#1231 @ 168,220: 10x21
#1232 @ 40,981: 11x14
#1233 @ 68,207: 10x11
#1234 @ 836,2: 22x19
#1235 @ 834,19: 29x20
#1236 @ 788,153: 28x29
#1237 @ 667,684: 15x19
#1238 @ 221,717: 13x11
#1239 @ 386,642: 24x29
#1240 @ 8,258: 28x27
#1241 @ 919,326: 15x26
#1242 @ 867,666: 18x23
#1243 @ 853,760: 20x24
#1244 @ 825,423: 16x27
#1245 @ 831,202: 21x13
#1246 @ 107,43: 12x22
#1247 @ 366,170: 21x15
#1248 @ 519,235: 13x11
#1249 @ 33,698: 27x19
#1250 @ 615,630: 26x16
#1251 @ 325,695: 17x19
#1252 @ 494,39: 17x23
#1253 @ 559,34: 27x29
#1254 @ 978,813: 20x28
#1255 @ 499,885: 10x22
#1256 @ 847,515: 19x23
#1257 @ 950,119: 21x28
#1258 @ 967,692: 15x15
#1259 @ 55,753: 22x15
#1260 @ 444,777: 29x16
#1261 @ 371,580: 29x18
#1262 @ 628,622: 29x18
#1263 @ 850,724: 18x22
#1264 @ 817,287: 22x27
#1265 @ 708,900: 3x10
#1266 @ 43,667: 11x20
#1267 @ 731,444: 20x10
#1268 @ 706,475: 16x10
#1269 @ 139,42: 28x23
#1270 @ 744,375: 27x27
#1271 @ 410,867: 13x27
#1272 @ 787,18: 13x15
#1273 @ 210,847: 15x25
#1274 @ 399,516: 13x19
#1275 @ 771,854: 23x17
#1276 @ 262,834: 27x29
#1277 @ 237,136: 29x13
#1278 @ 823,716: 23x21
#1279 @ 711,529: 23x26
#1280 @ 736,514: 25x18
#1281 @ 438,779: 14x12
#1282 @ 140,516: 19x18
#1283 @ 740,940: 29x15
#1284 @ 767,387: 29x18
#1285 @ 95,935: 16x17
#1286 @ 535,406: 14x25
#1287 @ 987,970: 11x17
#1288 @ 786,350: 22x15
#1289 @ 416,669: 5x10
#1290 @ 759,442: 28x29
#1291 @ 532,145: 22x15
#1292 @ 58,438: 19x26
#1293 @ 156,760: 29x13
#1294 @ 9,211: 10x11
#1295 @ 712,346: 19x28
#1296 @ 183,28: 10x26
#1297 @ 543,115: 22x22
#1298 @ 909,733: 22x29
#1299 @ 473,755: 21x14
#1300 @ 722,844: 26x26
#1301 @ 14,53: 26x22
#1302 @ 179,534: 14x24
#1303 @ 204,860: 17x12
#1304 @ 749,568: 23x13
#1305 @ 541,177: 24x14
#1306 @ 476,826: 21x14
#1307 @ 935,746: 28x21
#1308 @ 172,261: 12x22
#1309 @ 481,585: 11x27
#1310 @ 658,696: 13x19
#1311 @ 839,714: 23x23
#1312 @ 703,956: 10x11
#1313 @ 961,825: 11x12
#1314 @ 621,961: 18x16
#1315 @ 648,685: 28x14
#1316 @ 508,250: 12x21
#1317 @ 829,808: 28x26
#1318 @ 459,577: 28x11
#1319 @ 978,15: 13x18
#1320 @ 735,660: 15x13
#1321 @ 906,442: 17x12
#1322 @ 825,896: 22x29
#1323 @ 940,614: 24x27
#1324 @ 914,490: 16x27
#1325 @ 155,338: 29x25
#1326 @ 952,342: 16x18
#1327 @ 796,417: 26x10
#1328 @ 226,224: 14x22
#1329 @ 396,314: 17x22
#1330 @ 102,50: 13x13
#1331 @ 705,151: 28x25
#1332 @ 147,528: 28x11
#1333 @ 649,245: 10x11
#1334 @ 942,285: 17x24
#1335 @ 200,35: 20x13
#1336 @ 423,262: 29x24
#1337 @ 304,201: 10x10
#1338 @ 909,110: 22x15
#1339 @ 577,568: 25x29
#1340 @ 205,448: 11x28
#1341 @ 598,368: 26x19
#1342 @ 236,912: 24x17
#1343 @ 717,817: 20x27
#1344 @ 76,643: 10x28
#1345 @ 161,462: 26x17
#1346 @ 700,889: 11x25
#1347 @ 864,619: 19x17
#1348 @ 199,857: 24x21
#1349 @ 959,173: 24x20
#1350 @ 366,874: 10x13
#1351 @ 144,509: 11x26
#1352 @ 252,922: 11x25
#1353 @ 243,917: 28x18
#1354 @ 703,883: 21x11
#1355 @ 622,934: 23x11
#1356 @ 889,520: 24x23
#1357 @ 556,275: 29x27
#1358 @ 524,129: 13x23
#1359 @ 442,840: 23x16
#1360 @ 761,55: 22x21
#1361 @ 566,547: 25x28
#1362 @ 807,670: 17x24
#1363 @ 312,58: 26x19
#1364 @ 275,943: 10x27
#1365 @ 699,482: 23x11
#1366 @ 182,267: 21x15
#1367 @ 438,580: 20x11
#1368 @ 127,494: 13x26
#1369 @ 279,297: 15x29
#1370 @ 333,912: 25x28
#1371 @ 131,169: 18x26
#1372 @ 394,413: 15x13
#1373 @ 465,96: 23x10
#1374 @ 306,283: 10x27
#1375 @ 620,430: 18x25
#1376 @ 680,300: 14x22
#1377 @ 218,447: 27x23
#1378 @ 648,606: 12x28
#1379 @ 19,669: 20x12
#1380 @ 70,150: 11x28
#1381 @ 420,367: 17x12
#1382 @ 660,807: 23x18
#1383 @ 520,573: 29x15
#1384 @ 152,23: 28x26
#1385 @ 45,666: 21x22
#1386 @ 139,517: 15x11
#1387 @ 98,483: 24x19
#1388 @ 812,205: 17x11
#1389 @ 583,610: 11x14
#1390 @ 335,532: 18x12
#1391 @ 349,495: 12x26
#1392 @ 150,468: 16x25
#1393 @ 881,922: 17x21
#1394 @ 14,306: 15x18
#1395 @ 264,540: 15x19
#1396 @ 367,319: 29x11
#1397 @ 770,599: 15x13
#1398 @ 916,40: 22x27
#1399 @ 876,521: 22x15
#1400 @ 743,667: 19x24
#1401 @ 172,390: 28x11
#1402 @ 930,276: 12x27
#1403 @ 656,975: 12x17
#1404 @ 607,484: 17x25
#1405 @ 499,30: 12x11
#1406 @ 181,431: 23x12
#1407 @ 699,840: 28x17";
    }
  }
}

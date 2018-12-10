using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode
{
  public class Puzzle02
  {
    public static void Run1()
    {
      var twoCount = 0;
      var threeCount = 0;

      foreach (var item in Input().Split(Environment.NewLine))
      {
        bool hasTwoCount = false;
        bool hasThreeCount = false;

        var counts = new Dictionary<char, int>();
        foreach (var character in item)
        {
          if (counts.ContainsKey(character))
          {
            counts[character] += 1;
          }
          else
          {
            counts.Add(character, 1);
          }
        }
        foreach (var key in counts.Keys)
        {
          if(counts[key] == 2)
          hasTwoCount = true;
          if(counts[key] == 3)
          hasThreeCount = true;
        }
        if (hasTwoCount)
        {
          twoCount++;
        }
        if (hasThreeCount)
        {
          threeCount++;
        }
      }

      var result = twoCount * threeCount;
      Console.WriteLine(result);
    }

    public static void Run2()
    {
      var inputs = Input().Split(Environment.NewLine);

      foreach (var item1 in inputs)
      {
        foreach (var item2 in inputs)
        {
          if (item1 != item2)
          {
            var diffPositions = new List<int>();
            for(var i = 0; i < item1.Length; i++)
            {
              if (item1[i] != item2[i])
              {
                diffPositions.Add(i);
              }
              if (diffPositions.Count > 1)
              {
                break;
              }
            }

            if (diffPositions.Count == 1)
            {
              var result = string.Empty;
              for (var i = 0; i < item1.Length; i++)
              {
                if (i != diffPositions[0])
                {
                  result += item1[i];
                }
              }
              Console.WriteLine(result);
              break;
            }
          }
        }
        
      }
    }

    public static string Input()
    {
      

      return @"oeambtcgjqnzhgkdylfapoiusr
oewmbtcxjqnzhgvdyltapvqusr
oewmbtchjqnzigkdylfapviuse
oeimbucxjqnzhgkdyyfapviusr
fewmbtcxjqndhgcdylfapviusr
oevgbtccjqnzhgkdylfapviusr
oewmbtcxjqnzhnkdylmapvpusr
oewmbtcxjqnzhxkdyldapvirsr
oewmutccjqnzngkdylfapviusr
oewmbtcxbqnzhgkdsliapviusr
ozwmbtfxjqnzcgkdylfapviusr
oewmbtdxjqnzhgkdypfapsiusr
oeylbtcxjqnzhgyyylfapviusr
oewmbtcxjqnzhgkdrlfakuiusr
oewmbtcujqnxhgkdylfadviusr
oewmbtcxlqpzhgkdylfaaviusr
oewmztcxjqnzhgkdylfqpliusr
oeembtcxjqnzhgkdtlmapviusr
onwmbtcxjqnqhgkdylfapdiusr
oewmbtcxnqnzhgkdylfapsbusr
oeoibtjxjqnzhgkdylfapviusr
oxwmbtcxjqnzhgkdylfapcipsr
oewmbtoxbqnzhgzdylfapviusr
okwubtcxjqnzhgkdylfapiiusr
oewmbtcxjqnzhgodylfapnicsr
oewmitcxjqnzhgkdylfaphlusr
oewmbtaxjqnzhgkhylfapveusr
oewmftcbjqnzhgkdylfapviurr
oewmbtcujqnzbgkdylfapliusr
oeevbtcxjqnzhgkdylfapniusr
oewmbtcxjqnvhgkdylfapnpusr
oewabtcxjqnzhgddylfapviust
oewmbtyxjqnzhgkdvlfapvinsr
jewmbtcxjonzhzkdylfapviusr
oewmbrcxjqnzxgkdylfapoiusr
dewmbtmxjqnzhgkdyvfapviusr
oewmbtctjqnzhgkdmlfapvihsr
oewmbjcxjqnzhgvdylfapviurr
oewmbtcxjqnzhgcdxlfapvfusr
oewmbucxjqnzhgkdyltapvifsr
gewmbtcejqezhgkdylfapviusr
oewebtcxjznzhgkdylfapvhusr
oewmjtcxjqnzhgkdycfakviusr
oewmbtcxjtnvhgkdylfabviusr
oewmbtcxjqnthgkgclfapviusr
hewmbtcxjqnzhgkdwlfapziusr
oewmbtcxjqnzhgkdylfqpviysf
oewmbtcxjvnzhgmdylfapviuse
oewmbtcxjqnphgkdymzapviusr
oewmbtcxjqnzwmkdylfapvbusr
oewmbthxjqnzhgkdylfatvilsr
oewmbtcxaznzhgkhylfapviusr
zewmbscxjqnzhgkdylfatviusr
oewmbecyaqnzhgkdylfapviusr
oewmbtnxjqnzhekxylfapviusr
oewmbtcxjqczhgkdyltnpviusr
yewmbecxjnnzhgkdylfapviusr
oewmbocxjqnzhgkyylfapviusv
oewmxtcxjqnzhgkkylfspviusr
oiwmbtcxjqnzhgkdydfapvgusr
oewmbtcxjqnzngydylfwpviusr
oewmctcxjqnzhgkdelfapviasr
oewmbtcxjqnzhgxdwmfapviusr
oewmntcxjqnzhgkdylfamviusw
oewmatcxjqbzhgkdylfapvhusr
oewmbtcxjqnqhmkdyluapviusr
opwmbtcxjqnzhgkdywfapvilsr
omwmbtcxjqnlhgkdylyapviusr
oewmltcxoqnzhgkdylfapvfusr
oewmbtcxjqtzhgkdyyoapviusr
oewmbtcxjqnzhrkdzlffpviusr
oewmbtqxyqnzhgkdylfalviusr
oeuzbtcxlqnzhgkdylfapviusr
oewmbtcxjqnzhtxdylflpviusr
oewmdtfxjqnzhgkdylfapviufr
ojwmbtcxjqnzhgkdylfypviqsr
oewmbtcxjqnzhgkdylfapvivuf
oewmjtcsjqnzxgkdylfapviusr
ohembtcxjqnzhnkdylfapviusr
oewmptcajqnzhgkdylfapviusd
oewmbtcxjcnwhgkbylfapviusr
oewmbtcxjqnzhgddnlfapvqusr
oewmbtcfjqnzhgkdypfapvzusr
oewdbtccjqnzhgfdylfapviusr
oewmbtcxjpnzhgkdplfaqviusr
oepmbhcxjqnzhgkdylfaaviusr
oewmbtcwjqxzhgkwylfapviusr
oewmatcxjqnchgkdylfapvifsr
omwmbncxjqnzhgkdylfapviuyr
sewmbsckjqnzhgkdylfapviusr
oewubtcxjqnzhgkdyluapvausr
ohwmbtcxqqhzhgkdylfapviusr
oewmbtcxjqnzhgkpylfapnissr
eewmbccxjqnzhgkdylbapviusr
oewmitcyjqnzhgkdylkapviusr
oewmbtcxjvnzhgkdyjfvpviusr
oewmbtcxjqmzhgkdyefagviusr
oewmbtcvjqnzhgkdylpapviufr
oewmbtcxjrnkhgkdylfapsiusr
oewmbtcxjqnzygkdylfaxvipsr
oexmbtcxjqczhgkdyloapviusr
oewmbtcxjqnlhtkdylfapvmusr
oewmbtcxdqjzdgkdylfapviusr
oewmbtclgqnzhgkdylfabviusr
oewmbtvfjqnzhgkdylfapviulr
oewmbtcxjqnzhgkdyllarvijsr
oewmbtyxjqnzhgpdylxapviusr
oeylbtcxjqnzhgkyylfapviusr
oewmbtctjqnzhjkdylfapviulr
oermatcxjqnzhgkdylzapviusr
oewmbtcxjqnztgkdzlfapviutr
oewlbtcxjqnztgkvylfapviusr
oewmbtcxjqzvhgkdylfapviusk
oewmbtcxjqnzmgkdyldapvilsr
felmbtcxjqnzhgkdylfapviusl
oewmbtcxjgnzhgkjylfaeviusr
ovwmbtcxjqpzhgkdylfapvizsr
eewmbtcpjqnzhgkdylfapvijsr
oewmbzcxjqnzhgkdylfaeviutr
tewmbtcljqhzhgkdylfapviusr
oewmbtcujqnzhgkdnliapviusr
oewmbtcljqnzhskdylfapvgusr
oewmbtchjqnzhgkdylmapviuse
oewmbtcxjqnzbgkdylfaiviurr
oewmbtcxjqnzhkkdyloapsiusr
oewjbtcxjqnhhgkdylfapjiusr
odwmbtcnjqnzhgkdylfapvicsr
oewmbccxjqrzwgkdylfapviusr
kewmbtcvjqnzhgkdylaapviusr
okwmbtcxjqnzhgkdylfspvausr
oewmbtcxjynzhgkdyafapviusw
oewmbtcxjqnzhgwdyleayviusr
oewmbtcxjqnzhgkdylfapviicl
oewmbtcxjqnzhgkdyltaeziusr
oewmbtcxrqnzhgkdylftpvizsr
oewsrtcgjqnzhgkdylfapviusr
oewmbtsxgqnzhgxdylfapviusr
oewmbtcxjanzhgtdylfapeiusr
oewybtcgjqnzhgkdylfapviust
ojwmbncxjqnzhgkdylfapgiusr
ocgebtcxjqnzhgkdylfapviusr
oejcbtcxjqnzhgkvylfapviusr
oswmbtcxjqnkhgkdylfapviusb
oewdbtcxjqnzdgkdylfypviusr
oawmutcxjqnzhgkddlfapviusr
oewzbtcxyqnzhgkdylfapviusy
zewmbtcxjqnzkgkdylwapviusr
aewmbtkxjqnzhgkdylfapviuer
oewmbtcxwqnzhgkdyofapviuur
oewmbtcxjqnzggkdylfapanusr
oewmstcxuqnzhgkdylzapviusr
zewmbtcxjqozhgkdelfapviusr
oewzbtcxjqnahgkdyllapviusr
fewmatcxjqnghgkdylfapviusr
oewmbtcxjqnzhgkdylfapviyqb
oewwbtcxjqnzhgkdyljapviqsr
oewmbtbxjqnzhgkxylfapviesr
oewmbtcbjqnphgkdylfapviysr
oewabtcxyqnzhgkdylfabviusr
oewmbtcxhknzhgkdylfapviusd
ozwmbtcljqnzhgkdylfapviksr
tewmbtcxjqnzhgkdylfaxvqusr
oewmbtcxrqnzhgkdytfapvrusr
ohwmbtcxjcnzhgkdyifapviusr
oewmbpcxjqnzhwkdylfaphiusr
oedmbtcxjqnzhgnbylfapviusr
oewmbocxjqnehgkdylfapvbusr
oeymbtcxjqezegkdylfapviusr
oewmbtcxjqnzhgkdllferviusr
oewmbtcxjqnzhgkwmlfawviusr
oewmbtcxienzhgkdyzfapviusr
mewmbtcxjqnzhqkdylfapviwsr
oewmbtcxjqnztgkmylfapvdusr
ouwmbtcxjqnzhokdylpapviusr
oewmctcxjqhzhgmdylfapviusr
oewmbtcyjqnzhmkdylfarviusr
oewmbtcxjqnzhgkdpnfzpviusr
oewmptcxjqnzhgkdylkapviulr
nefmbtcxsqnzhgkdylfapviusr
oewmbtcxwqnzhgkdilfapvizsr
eewmbtcxjqwzhghdylfapviusr
oewmbtixmqnzhgkjylfapviusr
okwmbtcdzqnzhgkdylfapviusr
oewmbtxxjrnzigkdylfapviusr
oewmdycxjqnzhekdylfapviusr
oewmutcxjqnzhgkdylfapsiuqr
oewmbacxjqnzrgkdrlfapviusr
oewmbtcxpqnzhmkdylfapciusr
oewabtcxjqnzhgkdyrcapviusr
oswmbtcxjqnzhgkdrxfapviusr
gewmbtcnjqnzhgkdylvapviusr
newmbtcxjwnzfgkdylfapviusr
lewmbtcxjqnzhgkdylfaptiujr
oewwbtcxjqndhgkdylfapiiusr
oewmbtcxjqnzhggdylfapvqmsr
lewmbtcxjqnzhgkhllfapviusr
oewmbtocjqnzhgkdylfapvhusr
oedmbtcxjqnzhgkdyhfapviusb
oewmbtcxjqnzhgkdylfajvaosr
zewmbtcxjqnzhgkdylfapvsssr
oewmbthxjqnzhskdylfapviuqr
yewmrtcvjqnzhgkdylfapviusr
oewmbtctjqnzhgkdylfabvhusr
oesmstcxjqnzhgkdylfapqiusr
oewmbtcxjqnzzgkdylfopiiusr
otwmbtzxjqnzhgkdylfaxviusr
ouwmbxcxjqnzhgkdylfapvnusr
oewmbtcxjqezhgedylfapvsusr
oesmhtcsjqnzhgkdylfapviusr
oewdbtcxjqnzhgkdilfapvifsr
oewmbtcxjqnzhgudynfamviusr
qewhbtcxjqnzhgkdyxfapviusr
oewmbzcxjqtzhgkdylfapvitsr
oewmbtccjqzzhgkaylfapviusr
jewmbtcxmqnzhlkdylfapviusr
oewmbtcxjqbzhgkdnlfapviusp
oeimbtcdjqnzhgkdylfapviuer
oewtbtcxjqnihgkdylfahviusr
oewmbtcxhqnzhgkdylfapdiudr
oefmbtcxjqyshgkdylfapviusr
oewmbtcxjqnzhgkfglfapviusx
oecmbocxjqnzhgkdmlfapviusr
oewmbtcxjqnzhghdylfavviuhr
oewmbmcxiqnzhgkpylfapviusr
oewmbtcnjqnzhgkrylfanviusr
oewmbocxjqnzhzkdllfapviusr
eewmbtckjqnzhgkdylfapviusg
oewmbtcrjqqzhgkdylfapvigsr
oewmbtcxjqazhgfdylfapjiusr
oetmbtcxjqnzhgldylfapviqsr
oewbbtcxjqnzlgkdylfapviuse
oewmbtcxjqnzhglbolfapviusr
oewmbtcxjqnzcgkdylfapviuhy
oelmbtcxjqfzhgkdylaapviusr
oojmbycxjqnzhgkdylfapviusr
oewmbtrxjqnrhgkdylfapniusr
oewmbtcxjqnzhgkyyhfapviuso
oewabtcxjqnzhskdylfapviusx
oewmbtcrjqnmhgkdylfapvnusr
oewmbtcxjqrzhgkdylfapvpuss
oewmbtcxhqnzwgkddlfapviusr
kewmbtcxjqnzhgkyylfajviusr
oswmbtcxjqnzhgkdjlfapviuss
onwmbtcxjqnchgkdylfapvpusr
oeymbtcxjqnxhikdylfapviusr
oewmblcdjqnzhgkdylfapviysr
oewmbtcxeqczhgudylfapviusr
oewmbpgxjqnzhgkdylfapfiusr
ohwmwtcxjqnzhgkdylftpviusr
zebmbtuxjqnzhgkdylfapviusr";
    }
  }
}

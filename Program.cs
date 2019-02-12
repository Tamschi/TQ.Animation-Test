using System;
using System.IO;

namespace TQ.Animation_Test
{
    class Program
    {
        static void Main()
        {
            Span<byte> file = File.ReadAllBytes("animation.anm");
            var animation = new Animation.Animation(file);
            Console.WriteLine($"File format version: {animation.Header.Version}");
            Console.WriteLine($"Bone Count: {animation.Header.BoneCount}");
            Console.WriteLine($"Frame Count: {animation.Header.FrameCount}");
            Console.WriteLine($"FPS: {animation.Header.Fps}");

            var enumerator = animation.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var boneAnimation = enumerator.Current;
                Console.WriteLine($"Bone animation: {boneAnimation.Name}");
                foreach (ref var frame in boneAnimation.Frames)
                { Console.WriteLine(frame); }
            }
            Console.WriteLine("=== Text Data ===");
            Console.WriteLine(enumerator.TextAfterEnd);
        }
    }
}

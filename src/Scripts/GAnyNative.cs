using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace Gx
{
    public class GAnyNative
    {
        private const string libName = "gany-unity";

        [DllImport(libName, EntryPoint = "initGAny")]
        public static extern void CInitGAny();

        [DllImport(libName, EntryPoint = "ganySetFunctionProxy")]
        public static extern void CGAnySetFunctionProxy(IntPtr proxyFunc);
        
        [DllImport(libName, EntryPoint = "ganySetFunctionDtorListener")]
        public static extern void CGAnySetFunctionDtorListener(IntPtr listener);

        [DllImport(libName, EntryPoint = "ganyCreate")]
        public static extern long CGAnyCreate(long v);

        [DllImport(libName, EntryPoint = "ganyCreateBool")]
        public static extern long CGAnyCreateBool(bool v);

        [DllImport(libName, EntryPoint = "ganyCreateInt32")]
        public static extern long CGAnyCreateInt32(int v);

        [DllImport(libName, EntryPoint = "ganyCreateInt64")]
        public static extern long CGAnyCreateInt64(Int64 v);

        [DllImport(libName, EntryPoint = "ganyCreateInt8")]
        public static extern long CGAnyCreateInt8(byte v);

        [DllImport(libName, EntryPoint = "ganyCreateInt16")]
        public static extern long CGAnyCreateInt16(Int16 v);

        [DllImport(libName, EntryPoint = "ganyCreateFloat")]
        public static extern long CGAnyCreateFloat(float v);

        [DllImport(libName, EntryPoint = "ganyCreateDouble")]
        public static extern long CGAnyCreateDouble(double v);

        [DllImport(libName, EntryPoint = "ganyCreateString")]
        public static extern long CGAnyCreateString(string v);

        [DllImport(libName, EntryPoint = "ganyCreatePointer")]
        public static extern long CGAnyCreatePointer(IntPtr v);

        [DllImport(libName, EntryPoint = "ganyCreateArray")]
        public static extern long CGAnyCreateArray();

        [DllImport(libName, EntryPoint = "ganyCreateObject")]
        public static extern long CGAnyCreateObject();

        [DllImport(libName, EntryPoint = "ganyCreateFunction")]
        public static extern long CGAnyCreateFunction(long funcPtr);

        [DllImport(libName, EntryPoint = "ganyCreateUndefined")]
        public static extern long CGAnyCreateUndefined();

        [DllImport(libName, EntryPoint = "ganyCreateNull")]
        public static extern long CGAnyCreateNull();

        [DllImport(libName, EntryPoint = "ganyDestroy")]
        public static extern void CGAnyDestroy(long any);

        [DllImport(libName, EntryPoint = "ganyEnvironment")]
        public static extern long CGAnyEnvironment();


        [DllImport(libName, EntryPoint = "ganyClone")]
        public static extern long CGAnyClone(long any);

        [DllImport(libName, EntryPoint = "ganyFreeString")]
        public static extern void CGAnyFreeString(IntPtr str);

        [DllImport(libName, EntryPoint = "ganyClassTypeName")]
        public static extern IntPtr CGAnyClassTypeName(long any);

        [DllImport(libName, EntryPoint = "ganyTypeName")]
        public static extern IntPtr CGAnyTypeName(long any);

        [DllImport(libName, EntryPoint = "ganyLength")]
        public static extern int CGAnyLength(long any);

        [DllImport(libName, EntryPoint = "ganySize")]
        public static extern int CGAnySize(long any);

        [DllImport(libName, EntryPoint = "ganyIs")]
        public static extern bool CGAnyIs(long any, string typeStr);

        [DllImport(libName, EntryPoint = "ganyIsUndefined")]
        public static extern bool CGAnyIsUndefined(long any);

        [DllImport(libName, EntryPoint = "ganyIsNull")]
        public static extern bool CGAnyIsNull(long any);

        [DllImport(libName, EntryPoint = "ganyIsFunction")]
        public static extern bool CGAnyIsFunction(long any);

        [DllImport(libName, EntryPoint = "ganyIsClass")]
        public static extern bool CGAnyIsClass(long any);

        [DllImport(libName, EntryPoint = "ganyIsProperty")]
        public static extern bool CGAnyIsProperty(long any);

        [DllImport(libName, EntryPoint = "ganyIsEnum")]
        public static extern bool CGAnyIsEnum(long any);

        [DllImport(libName, EntryPoint = "ganyIsObject")]
        public static extern bool CGAnyIsObject(long any);

        [DllImport(libName, EntryPoint = "ganyIsArray")]
        public static extern bool CGAnyIsArray(long any);

        [DllImport(libName, EntryPoint = "ganyIsInt32")]
        public static extern bool CGAnyIsInt32(long any);

        [DllImport(libName, EntryPoint = "ganyIsInt64")]
        public static extern bool CGAnyIsInt64(long any);

        [DllImport(libName, EntryPoint = "ganyIsInt8")]
        public static extern bool CGAnyIsInt8(long any);

        [DllImport(libName, EntryPoint = "ganyIsInt16")]
        public static extern bool CGAnyIsInt16(long any);

        [DllImport(libName, EntryPoint = "ganyIsFloat")]
        public static extern bool CGAnyIsFloat(long any);

        [DllImport(libName, EntryPoint = "ganyIsDouble")]
        public static extern bool CGAnyIsDouble(long any);
        
        [DllImport(libName, EntryPoint = "ganyIsNumber")]
        public static extern bool CGAnyIsNumber(long any);

        [DllImport(libName, EntryPoint = "ganyIsString")]
        public static extern bool CGAnyIsString(long any);

        [DllImport(libName, EntryPoint = "ganyIsBoolean")]
        public static extern bool CGAnyIsBoolean(long any);

        [DllImport(libName, EntryPoint = "ganyIsUserObject")]
        public static extern bool CGAnyIsUserObject(long any);

        [DllImport(libName, EntryPoint = "ganyIsPointer")]
        public static extern bool CGAnyIsPointer(long any);

        [DllImport(libName, EntryPoint = "ganyToInt32")]
        public static extern int CGAnyToInt32(long any);

        [DllImport(libName, EntryPoint = "ganyToInt64")]
        public static extern Int64 CGAnyToInt64(long any);

        [DllImport(libName, EntryPoint = "ganyToInt8")]
        public static extern byte CGAnyToInt8(long any);

        [DllImport(libName, EntryPoint = "ganyToInt16")]
        public static extern Int16 CGAnyToInt16(long any);

        [DllImport(libName, EntryPoint = "ganyToFloat")]
        public static extern float CGAnyToFloat(long any);

        [DllImport(libName, EntryPoint = "ganyToDouble")]
        public static extern double CGAnyToDouble(long any);

        [DllImport(libName, EntryPoint = "ganyToBool")]
        public static extern bool CGAnyToBool(long any);

        [DllImport(libName, EntryPoint = "ganyToString")]
        public static extern IntPtr CGAnyToString(long any);

        [DllImport(libName, EntryPoint = "ganyToJsonString")]
        public static extern IntPtr CGAnyToJsonString(long any, int indent);
        
        [DllImport(libName, EntryPoint = "ganyToObject")]
        public static extern long CGAnyToObject(long any);

        [DllImport(libName, EntryPoint = "ganyParseJson")]
        public static extern long CGAnyParseJson(string json);

        [DllImport(libName, EntryPoint = "ganyToPointer")]
        public static extern IntPtr CGAnyToPointer(long any);

        [DllImport(libName, EntryPoint = "ganyDump")]
        public static extern IntPtr CGAnyDump(long any);

        [DllImport(libName, EntryPoint = "ganyContains")]
        public static extern bool CGAnyContains(long any, long id);

        [DllImport(libName, EntryPoint = "ganyErase")]
        public static extern void CGAnyErase(long any, long id);

        [DllImport(libName, EntryPoint = "ganyPushBack")]
        public static extern void CGAnyPushBack(long any, long rh);

        [DllImport(libName, EntryPoint = "ganyClear")]
        public static extern void CGAnyClear(long any);
        
        [DllImport(libName, EntryPoint = "ganyIterator")]
        public static extern long CGAnyIterator(long any);
        
        [DllImport(libName, EntryPoint = "ganyHasNext")]
        public static extern bool CGAnyHasNext(long any);
        
        [DllImport(libName, EntryPoint = "ganyNext")]
        public static extern long CGAnyNext(long any);

        [DllImport(libName, EntryPoint = "ganyCallMethod")]
        public static extern long CGAnyCallMethod(long any, string methodName, long[] args, int argc);

        [DllImport(libName, EntryPoint = "ganyCallFunction")]
        public static extern long CGAnyCallFunction(long any, long[] args, int argc);

        [DllImport(libName, EntryPoint = "ganyGetItem")]
        public static extern long CGAnyGetItem(long any, long i);

        [DllImport(libName, EntryPoint = "ganySetItem")]
        public static extern void CGAnySetItem(long any, long i, long v);

        [DllImport(libName, EntryPoint = "ganyDelItem")]
        public static extern void CGAnyDelItem(long any, long i);

        [DllImport(libName, EntryPoint = "ganyOperatorNeg")]
        public static extern long CGAnyOperatorNeg(long any);

        [DllImport(libName, EntryPoint = "ganyOperatorAdd")]
        public static extern long CGAnyOperatorAdd(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorSub")]
        public static extern long CGAnyOperatorSub(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorMul")]
        public static extern long CGAnyOperatorMul(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorDiv")]
        public static extern long CGAnyOperatorDiv(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorMod")]
        public static extern long CGAnyOperatorMod(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorBitXor")]
        public static extern long CGAnyOperatorBitXor(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorBitOr")]
        public static extern long CGAnyOperatorBitOr(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorBitAnd")]
        public static extern long CGAnyOperatorBitAnd(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorBitNot")]
        public static extern long CGAnyOperatorBitNot(long v);

        [DllImport(libName, EntryPoint = "ganyOperatorEqualTo")]
        public static extern bool CGAnyOperatorEqualTo(long a, long b);

        [DllImport(libName, EntryPoint = "ganyOperatorLessThan")]
        public static extern bool CGAnyOperatorLessThan(long a, long b);


        public delegate GAny GAnyFunction(GAny[] args);

        private delegate long CAnyFunctionProxyDelegate(long funcPtr, IntPtr args, int argc);

        private delegate void CAnyFunctionDtorListenerDelegate(long funcPtr);

        private static GAnyNative _instance;

        private readonly CAnyFunctionProxyDelegate _cAnyFunctionProxyDelegate;
        private readonly CAnyFunctionDtorListenerDelegate _cAnyFunctionDtorListenerDelegate;

        private readonly Dictionary<long, GAnyFunction> _gAnyFunctionMap = new();

        public static GAnyNative Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GAnyNative();
                }

                return _instance;
            }
        }

        public void Init()
        {
            CGAnySetFunctionProxy(Marshal.GetFunctionPointerForDelegate(_cAnyFunctionProxyDelegate));
            CGAnySetFunctionDtorListener(Marshal.GetFunctionPointerForDelegate(_cAnyFunctionDtorListenerDelegate));
        }

        public void UnInit()
        {
            CGAnySetFunctionProxy(IntPtr.Zero);
            CGAnySetFunctionDtorListener(IntPtr.Zero);
        }

        private GAnyNative()
        {
            CInitGAny();
            _cAnyFunctionProxyDelegate = CAnyFunctionProxy;
            _cAnyFunctionDtorListenerDelegate = CAnyFunctionDtorListener;
        }

        private long CAnyFunctionProxy(long funcPtr, IntPtr args, int argc)
        {
            GAnyFunction func;
            lock (_gAnyFunctionMap)
            {
                if (!_gAnyFunctionMap.ContainsKey(funcPtr))
                {
                    Debug.LogError($"Can not find GAnyFunction: {funcPtr}");
                    return 0;
                }

                func = _gAnyFunctionMap[funcPtr];
            }

            long[] argss = new long[argc];
            Marshal.Copy(args, argss, 0, argc);

            var ganyArgs = new GAny[argc];
            for (var i = 0; i < argc; i++)
            {
                ganyArgs[i] = GAny.CreateFromPtr(argss[i]);
            }

            GAny ret = func(ganyArgs);
            long retPtrCopy = CGAnyCreate(ret.NativePtr());
            return retPtrCopy;
        }

        private void CAnyFunctionDtorListener(long funcPtr)
        {
            lock (_gAnyFunctionMap)
            {
                if (_gAnyFunctionMap.ContainsKey(funcPtr))
                {
                    _gAnyFunctionMap.Remove(funcPtr);
                }
            }
        }

        public long RegisterFunction(GAnyFunction function)
        {
            long newPtr = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            lock (_gAnyFunctionMap)
            {
                while (_gAnyFunctionMap.ContainsKey(newPtr))
                {
                    newPtr++;
                }

                _gAnyFunctionMap.TryAdd(newPtr, function);
            }

            return CGAnyCreateFunction(newPtr);
        }
    }
}
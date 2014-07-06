﻿/*The MIT License (MIT)

Copyright (c) 2014 PMU Staff

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Maps
{
    public class ActiveNpcCollection
    {
        DataManager.Maps.MapDump rawMap;
        MapNpc[] mapNpcs;

        public ActiveNpcCollection(DataManager.Maps.MapDump rawMap) {
            this.rawMap = rawMap;
            mapNpcs = new MapNpc[rawMap.ActiveNpc.Length];
            for (int i = 0; i < mapNpcs.Length; i++) {
                mapNpcs[i] = new MapNpc(rawMap.MapID, rawMap.ActiveNpc[i]);
            }
        }

        public int Length {
            get { return mapNpcs.Length; }
        }

        public MapNpc this[int index] {
            get {
                return mapNpcs[index];
            }
            set {
                mapNpcs[index] = value;
                rawMap.ActiveNpc[index] = value.RawNpc;
            }
        }

        public System.Collections.IEnumerator GetEnumerator() {
            return mapNpcs.GetEnumerator();
        }
    }
}
